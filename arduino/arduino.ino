// Display & Touch Libraries
#include <Adafruit_GFX.h>
#include <MCUFRIEND_kbv.h>
#include <TouchScreen.h>

const int XP=7,XM=A1,YP=A2,YM=6; //240x320 ID=0x9325
const int TS_LEFT=138,TS_RT=882,TS_TOP=89,TS_BOT=905;

#define MINPRESSURE 200
#define MAXPRESSURE 1000

TouchScreen ts = TouchScreen(XP, YP, XM, YM, 300);
MCUFRIEND_kbv tft;

// SD Card
#include <SD.h>
#include <SPI.h>

#define SD_CS 10

// Colors
#define BLACK   0x0000
#define BLUE    0x001F
#define RED     0xF800
#define GREEN   0x07E0
#define CYAN    0x07FF
#define MAGENTA 0xF81F
#define YELLOW  0xFFE0
#define WHITE   0xFFFF
#define GREY      0xCE79
#define LIGHTGREY 0xDEDB

// Custom Headers
#include "bmp.h"
#include "objects.h"
#include "Vector.h"

Vector<Person*> persons;
String prefix;
boolean loaded=false;

boolean display_enroll=false;
int index_enroll=0;

int pixel_x, pixel_y;     //Touch_getXY() updates global vars
bool Touch_getXY(void)
{
    TSPoint p = ts.getPoint();
    pinMode(YP, OUTPUT);      //restore shared pins
    pinMode(XM, OUTPUT);
    digitalWrite(YP, HIGH);   //because TFT control pins
    digitalWrite(XM, HIGH);
    bool pressed = (p.z > MINPRESSURE && p.z < MAXPRESSURE);
    if (pressed) {
        //pixel_x = map(p.x, TS_MINX, TS_MAXX, 0, tft.width()); //.kbv makes sense to me
        //pixel_y = map(p.y, TS_MINY, TS_MAXY, 0, tft.height());
        pixel_x = map(p.x, TS_LEFT, TS_RT, 0, tft.width()); //.kbv makes sense to me
        pixel_y = map(p.y, TS_TOP, TS_BOT, 0, tft.height());
    }
    return pressed;
}

void displayHome() {
  Adafruit_GFX_Button btn_enroll, btn_mark;
  
  btn_enroll.initButton(&tft,  120, 248, 150, 40, BLACK, WHITE, BLACK, "ENROLL", 2);
  btn_mark.initButton(&tft, 120, 290, 150, 40, BLACK, WHITE, BLACK, "MARK", 2);
  
  tft.fillScreen(WHITE);
  bmpDraw(tft, "logo.bmp", 20, 10);

  if (!loaded) {
    prefix = readPrefix();
    Serial.print("Prefix:");
    Serial.println(prefix);
    readData(&persons);
    loaded=true;
  }
  
  btn_enroll.drawButton(false);
  btn_mark.drawButton(false);
    
  while (true) {
    bool down = Touch_getXY();
    
    btn_enroll.press(down && btn_enroll.contains(pixel_x, pixel_y));
    btn_mark.press(down && btn_mark.contains(pixel_x, pixel_y));
    if (btn_enroll.justReleased())
        btn_enroll.drawButton();
    if (btn_mark.justReleased())
        btn_mark.drawButton();
    if (btn_enroll.justPressed()) {
        btn_enroll.drawButton(true);
        display_enroll = true;
        break;
    }
    if (btn_mark.justPressed()) {
        btn_mark.drawButton(true);
        break;
    }
  }
}

void writePersonInfo() {
  tft.fillRect(10, 50, 220, 220, WHITE);

  Person* person = persons[index_enroll];

  tft.setCursor(15, 55);
  tft.setTextColor(GREY);
  tft.print("Regno:");
  tft.setCursor(15, 75);
  tft.setTextColor(BLACK);
  tft.print("  ");
  tft.print(prefix);
  tft.print(person->regno);

  tft.setCursor(15, 105);
  tft.setTextColor(GREY);
  tft.print("Name:");
  tft.setCursor(15, 125);
  tft.setTextColor(BLACK);
  tft.print("  ");
  tft.print(person->name);

  tft.setCursor(15, 155);
  tft.setTextColor(GREY);
  tft.print("Enrolled:");
  tft.setCursor(15, 175);
  tft.setTextColor(BLACK);
  tft.print("  ");
  if (person->fingerprint > 0)
    tft.print("YES");
  else
    tft.print("NO");
}

void displayEnroll() {
  Adafruit_GFX_Button btn_back, btn_previous, btn_enroll, btn_next;

  btn_back.initButton(&tft, 25, 20, 50, 40, BLACK, WHITE, BLACK, "<-", 2);
  btn_previous.initButton(&tft, 25, 300, 50, 40, BLACK, WHITE, BLACK, "<", 2);
  btn_enroll.initButton(&tft,  120, 300, 140, 40, BLACK, WHITE, BLACK, "ENROLL", 2);  
  btn_next.initButton(&tft, 215, 300, 50, 40, BLACK, WHITE, BLACK, ">", 2);
  
  tft.fillScreen(WHITE);

  btn_back.drawButton(false);
  btn_previous.drawButton(false);
  btn_enroll.drawButton(false);
  btn_next.drawButton(false);

  index_enroll = 0;
  writePersonInfo();

  while (true) {
    bool down = Touch_getXY();

    btn_back.press(down && btn_back.contains(pixel_x, pixel_y));
    btn_previous.press(down && btn_previous.contains(pixel_x, pixel_y));
    btn_enroll.press(down && btn_enroll.contains(pixel_x, pixel_y));
    btn_next.press(down && btn_next.contains(pixel_x, pixel_y));
    
    if (btn_back.justReleased())
        btn_back.drawButton();
    if (btn_previous.justReleased())
        btn_previous.drawButton();
    if (btn_enroll.justReleased())
        btn_enroll.drawButton();
    if (btn_next.justReleased())
        btn_next.drawButton();
    
    if (btn_back.justPressed()) {
        btn_back.drawButton(true);        
        break;
    }
    if (btn_previous.justPressed() && index_enroll > 0) {
        index_enroll -= 1;
        btn_previous.drawButton(true);
        writePersonInfo();
    }
    if (btn_enroll.justPressed()) {
        btn_enroll.drawButton(true);
        break;
    }
    if (btn_next.justPressed() && index_enroll < persons.Size() - 1) {
        index_enroll += 1;
        btn_next.drawButton(true);
        writePersonInfo();
    }
  }
}

void setup() {
  Serial.begin(9600);
  Serial.println("Initializing Device...");

  // Display & Touchscreen
  tft.reset();
  uint16_t identifier = tft.readID();
  tft.begin(identifier);
  tft.setRotation(0);

  // SD Card
  pinMode(SD_CS, OUTPUT);
  digitalWrite(SD_CS, HIGH);
  
  if (!SD.begin(SD_CS)) {
    Serial.println("SD Card: Initialization failed!");
    return;
  }
}

void loop() {  
  displayHome();

  if (display_enroll) {
    display_enroll = false;
    displayEnroll();
  }
}
