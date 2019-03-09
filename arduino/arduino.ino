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

// Fingerprint
#include <Adafruit_Fingerprint.h>

SoftwareSerial fpSerial(A14, A15);

Adafruit_Fingerprint finger = Adafruit_Fingerprint(&fpSerial);

// RTC
#include <Wire.h>
#include "RTClib.h"

RTC_DS1307 RTC;

// Custom Headers
#include "bmp.h"
#include "objects.h"
#include "Vector.h"

// Fingerprint Icon
static const uint8_t fp_icon [] PROGMEM = {
0x0,0x0,0x0,0x0,0x0,0x0,0x0,0x0,
0x0,0x0,0x0,0x0,0x0,0x0,0x0,0x0,
0x0,0x0,0x0,0x0,0x0,0x0,0x0,0x0,
0x0,0x0,0x0,0x3f,0xc0,0x0,0x0,0x0,
0x0,0x0,0x3,0xff,0xf8,0x0,0x0,0x0,
0x0,0x0,0x7,0xff,0xfe,0x0,0x0,0x0,
0x0,0x0,0x1f,0xc0,0x7f,0x80,0x0,0x0,
0x0,0x0,0x3e,0x0,0x7,0xc0,0x0,0x0,
0x0,0x0,0x7c,0x0,0x3,0xe0,0x0,0x0,
0x0,0x0,0xfd,0xff,0x81,0xf0,0x0,0x0,
0x0,0x0,0xff,0xff,0xe0,0xf0,0x0,0x0,
0x0,0x1,0xff,0xff,0xf8,0x78,0x0,0x0,
0x0,0x1,0xff,0x80,0x7c,0x38,0x0,0x0,
0x0,0x3,0xfc,0x0,0xe,0x3c,0x0,0x0,
0x0,0x3,0xf0,0x0,0x7,0x1c,0x0,0x0,
0x0,0x7,0xc0,0x7f,0x83,0x8e,0x0,0x0,
0x0,0x7,0x83,0xff,0xe0,0xe,0x0,0x0,
0x0,0x7,0xf,0xff,0xf8,0xf,0x0,0x0,
0x0,0x6,0x1f,0x80,0xfc,0x7,0x0,0x0,
0x0,0x4,0x7e,0x0,0x3f,0x7,0x0,0x0,
0x0,0x0,0xf8,0x0,0xf,0x7,0x0,0x0,
0x0,0x0,0xf0,0x3e,0x7,0x87,0x0,0x0,
0x0,0x1,0xe1,0xff,0x83,0x83,0x80,0x0,
0x0,0x3,0xc3,0xff,0xc3,0xc3,0x80,0x0,
0x0,0x3,0xc7,0xc3,0xe1,0xc3,0x80,0x0,
0x0,0x3,0x8f,0x0,0xf1,0xe3,0x80,0x0,
0x0,0x7,0x1e,0x0,0x78,0xe3,0x80,0x0,
0x0,0x7,0x1e,0x3c,0x38,0xe3,0x80,0x0,
0x0,0x7,0x1c,0x7e,0x38,0xe3,0x80,0x0,
0x0,0xf,0x1c,0x7f,0x38,0xe3,0x80,0x0,
0x0,0xe,0x3c,0xf7,0x38,0x71,0x80,0x0,
0x0,0xe,0x38,0xe7,0x38,0x71,0xc0,0x0,
0x0,0xe,0x38,0xe7,0x38,0x71,0xc0,0x0,
0x0,0xe,0x38,0xe7,0x38,0x73,0xc0,0x0,
0x0,0xe,0x38,0xe3,0x98,0xe3,0xc0,0x0,
0x0,0xe,0x38,0xe3,0xb8,0xe3,0x80,0x0,
0x0,0x0,0x38,0xe3,0xf8,0xe3,0x80,0x0,
0x0,0x0,0x38,0xe3,0xf8,0xe3,0x80,0x0,
0x0,0x0,0x3c,0xf1,0xf1,0xe3,0x80,0x0,
0x0,0x6,0x1c,0x70,0x1,0xc7,0x80,0x0,
0x0,0xe,0x1c,0x78,0x3,0xc7,0x80,0x0,
0x0,0xf,0x1c,0x3e,0x7,0x87,0x0,0x0,
0x0,0xf,0x1e,0x3f,0xff,0x8f,0x0,0x0,
0x0,0xf,0x1e,0x1f,0xff,0x1f,0x0,0x0,
0x0,0xf,0xf,0x7,0xfc,0x3e,0x0,0x0,
0x0,0x7,0x87,0x80,0x0,0x7c,0x0,0x0,
0x0,0x7,0x87,0xe0,0x0,0xfc,0x0,0x0,
0x0,0x3,0xc3,0xf8,0x7,0xf8,0x0,0x0,
0x0,0x3,0xe1,0xff,0xff,0xe1,0x0,0x0,
0x0,0x1,0xe0,0x7f,0xff,0x83,0x0,0x0,
0x0,0x1,0xf8,0xf,0xfe,0x7,0x0,0x0,
0x0,0x0,0xfc,0x0,0x0,0xe,0x0,0x0,
0x0,0x0,0x3f,0x0,0x0,0x3c,0x0,0x0,
0x0,0x0,0x1f,0xe0,0x1,0xf8,0x0,0x0,
0x0,0x0,0x7,0xff,0xff,0xf0,0x0,0x0,
0x0,0x0,0x1,0xff,0xff,0xc0,0x0,0x0,
0x0,0x0,0x0,0x1f,0xfc,0x0,0x0,0x0,
0x0,0x0,0x0,0x0,0x0,0x0,0x0,0x0,
0x0,0x0,0x0,0x0,0x0,0x0,0x0,0x0,
0x0,0x0,0x0,0x0,0x0,0x0,0x0,0x0
};

Vector<Staff*> staffs;
Vector<Student*> students;
String prefix;
int shift;
boolean loaded = false;

boolean display_enroll = false;
enum types type_enroll = TStudent;
int index_enroll = 0;

boolean display_mark = false;

int fingerprintID = 0;

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
    shift = readShift();
    readStaffs(&staffs);
    readStudents(&students);
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
        display_mark = true;
        break;
    }
  }
}

void writePersonInfo() {
  tft.fillRect(10, 50, 220, 220, WHITE);

  switch(type_enroll) {
    case TStudent: {
      Student *student = students[index_enroll];
      
      tft.setCursor(15, 55);
      tft.setTextColor(GREY);
      tft.print("Regno:");
      tft.setCursor(15, 75);
      tft.setTextColor(BLACK);
      tft.print("  ");
      tft.print(prefix);
      tft.print(shift - 1);
      tft.print(student->regno);
      
      tft.setCursor(15, 105);
      tft.setTextColor(GREY);
      tft.print("Name:");
      tft.setCursor(15, 125);
      tft.setTextColor(BLACK);
      tft.print("  ");
      tft.print(student->name);

      tft.setCursor(15, 155);
      tft.setTextColor(GREY);
      tft.print("Enrolled:");
      tft.setCursor(15, 175);
      tft.setTextColor(BLACK);
      tft.print("  ");
      if (student->fingerprint > 0)
        tft.print("YES");
      else
        tft.print("NO");
      break;
    } case TStaff: {
      Staff *staff = staffs[index_enroll];
      
      tft.setCursor(15, 55);
      tft.setTextColor(GREY);
      tft.print("ID:");
      tft.setCursor(15, 75);
      tft.setTextColor(BLACK);
      tft.print("  ");
      tft.print(staff->id);
      
      tft.setCursor(15, 105);
      tft.setTextColor(GREY);
      tft.print("Name:");
      tft.setCursor(15, 125);
      tft.setTextColor(BLACK);
      tft.print("  ");
      tft.print(staff->name);

      tft.setCursor(15, 155);
      tft.setTextColor(GREY);
      tft.print("Enrolled:");
      tft.setCursor(15, 175);
      tft.setTextColor(BLACK);
      tft.print("  ");
      if (staff->fingerprint > 0)
        tft.print("YES");
      else
        tft.print("NO");
      break;
    }
  }
}

void displaySelectType() {
  Adafruit_GFX_Button btn_back, btn_staff, btn_student;

  btn_back.initButton(&tft, 25, 20, 50, 40, BLACK, WHITE, BLACK, "<-", 2);
  btn_staff.initButton(&tft, 120, 140, 150, 40, BLACK, WHITE, BLACK, "STAFF", 2);
  btn_student.initButton(&tft, 120, 180, 150, 40, BLACK, WHITE, BLACK, "STUDENT", 2);

DISPSELECT:
  tft.fillScreen(WHITE);

  btn_back.drawButton(false);
  btn_staff.drawButton(false);
  btn_student.drawButton(false);

  while (true) {
    bool down = Touch_getXY();

    btn_back.press(down && btn_back.contains(pixel_x, pixel_y));
    btn_staff.press(down && btn_staff.contains(pixel_x, pixel_y));
    btn_student.press(down && btn_student.contains(pixel_x, pixel_y));
    
    if (btn_back.justReleased())
        btn_back.drawButton();
    if (btn_staff.justReleased())
        btn_staff.drawButton();
    if (btn_student.justReleased())
        btn_student.drawButton();
    
    if (btn_back.justPressed()) {
        btn_back.drawButton(true);     
        break;
    }
    if (btn_staff.justPressed()) {
        btn_staff.drawButton(true);
        type_enroll = TStaff;
        displayEnroll();
        goto DISPSELECT;
    }
    if (btn_student.justPressed()) {
        btn_student.drawButton(true);
        type_enroll = TStudent;
        displayEnroll();
        goto DISPSELECT;
    }
  }
}

void displayEnroll() {
  Adafruit_GFX_Button btn_back, btn_previous, btn_enroll, btn_next;

  btn_back.initButton(&tft, 25, 20, 50, 40, BLACK, WHITE, BLACK, "<-", 2);
  btn_previous.initButton(&tft, 25, 300, 50, 40, BLACK, WHITE, BLACK, "<", 2);
  btn_enroll.initButton(&tft,  120, 300, 140, 40, BLACK, WHITE, BLACK, "ENROLL", 2);  
  btn_next.initButton(&tft, 215, 300, 50, 40, BLACK, WHITE, BLACK, ">", 2);
  index_enroll = 0;

DISPENROLL:
  tft.fillScreen(WHITE);

  btn_back.drawButton(false);
  btn_previous.drawButton(false);
  btn_enroll.drawButton(false);
  btn_next.drawButton(false);
  
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
        displayEnrollFP();
        goto DISPENROLL;
        break;
    }
    if (btn_next.justPressed()) {
        int index_max = -1;
        switch (type_enroll) {
          case TStudent:
            index_max = students.Size() - 1;
            break;
          case TStaff:
            index_max = staffs.Size() - 1;
            break;
        }
        if (index_enroll < index_max) {
          index_enroll += 1;
          btn_next.drawButton(true);
          writePersonInfo();
        }
    }
  }
}

void writeFPEnrollInfo() {
  tft.fillRect(10, 50, 220, 100, WHITE);

  String name = "";
  fingerprintID = 0;  

  switch(type_enroll) {
    case TStudent: {
      Student *student = students[index_enroll];
      name = student->name;
      fingerprintID = student->regno.toInt() + 100;
      break;
    } case TStaff: {
      Staff *staff = staffs[index_enroll];
      name = staff->name;
      fingerprintID = staff->id;
      break;
    }
  }

  tft.setCursor(15, 55);
  tft.setTextColor(GREY);
  tft.print("Fingerprint ID:");
  tft.setCursor(15, 75);
  tft.setTextColor(BLACK);
  tft.print("  ");
  tft.print(fingerprintID);
  
  tft.setCursor(15, 105);
  tft.setTextColor(GREY);
  tft.print("Name:");
  tft.setCursor(15, 125);
  tft.setTextColor(BLACK);
  tft.print("  ");
  tft.print(name);
}

void showEnrollFPIcon(String msg, uint16_t color, int waitsec) {
  tft.fillRect(10, 155, 220, 155, WHITE);
  tft.drawRect(56, 155, 128, 120, BLACK);
  tft.setCursor(70, 165);
  tft.setTextColor(RED); 
  tft.setTextSize(2);
  tft.print("FP ENROLL");

  tft.setCursor(15, 290);
  tft.setTextColor(color); 
  tft.setTextSize(2);
  tft.print(msg);

  tft.drawBitmap(86, 185, fp_icon, 60, 60, color);
  delay(waitsec * 1000);
}

void displayEnrollFP() {
  Adafruit_GFX_Button btn_back;

  btn_back.initButton(&tft, 25, 20, 50, 40, BLACK, WHITE, BLACK, "<-", 2);
  
  tft.fillScreen(WHITE);

  btn_back.drawButton(false);

  writeFPEnrollInfo();

  boolean writeicon = true;
  int p = -1;
  while (true) {
ENROLLLOOP:
    if (writeicon) {
      showEnrollFPIcon(String("   Place finger"), BLUE, 0);
      writeicon = false;
    }
    bool down = Touch_getXY();

    btn_back.press(down && btn_back.contains(pixel_x, pixel_y));
    
    if (btn_back.justReleased())
        btn_back.drawButton();
    
    if (btn_back.justPressed()) {
        btn_back.drawButton(true);        
        break;
    }

    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      break;
    case FINGERPRINT_IMAGEFAIL:
      Serial.println("Imaging error");
      break;
    default:
      Serial.println("Unknown error");
      break;
    }

    if (p != FINGERPRINT_OK) {
      goto ENROLLLOOP;
    }

    p = finger.image2Tz(1);
    switch (p) {
      case FINGERPRINT_OK:
        Serial.println("Image converted");
        break;
      case FINGERPRINT_IMAGEMESS:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Image too messy");
        writeicon = true;
        goto ENROLLLOOP;
      case FINGERPRINT_PACKETRECIEVEERR:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Communication error");
        writeicon = true;
        goto ENROLLLOOP;
      case FINGERPRINT_FEATUREFAIL:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Could not find fingerprint features");
        writeicon = true;
        goto ENROLLLOOP;
      case FINGERPRINT_INVALIDIMAGE:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Could not find fingerprint features");
        writeicon = true;
        goto ENROLLLOOP;
      default:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Unknown error");
        writeicon = true;
        goto ENROLLLOOP;
    }

    showEnrollFPIcon(String("  Remove finger"), GREEN, 0);
    p = 0;
    while (p != FINGERPRINT_NOFINGER) {
      p = finger.getImage();
    }
    
    p = -1;
    showEnrollFPIcon(String("Place finger again"), BLUE, 0);
    while (p != FINGERPRINT_OK) {
      p = finger.getImage();
      switch (p) {
        case FINGERPRINT_OK:
          Serial.println("Image taken");
          break;
        case FINGERPRINT_NOFINGER:
          break;
        case FINGERPRINT_PACKETRECIEVEERR:
          Serial.println("Communication error");
          break;
        case FINGERPRINT_IMAGEFAIL:
          Serial.println("Imaging error");
          break;
        default:
          Serial.println("Unknown error");
          break;
      }
    }
    
    p = finger.image2Tz(2);
    switch (p) {
      case FINGERPRINT_OK:
        Serial.println("Image converted");
        break;
      case FINGERPRINT_IMAGEMESS:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Image too messy");
        writeicon = true;
        goto ENROLLLOOP;
      case FINGERPRINT_PACKETRECIEVEERR:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Communication error");
        writeicon = true;
        goto ENROLLLOOP;
      case FINGERPRINT_FEATUREFAIL:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Could not find fingerprint features");
        writeicon = true;
        goto ENROLLLOOP;
      case FINGERPRINT_INVALIDIMAGE:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Could not find fingerprint features");
        writeicon = true;
        goto ENROLLLOOP;
      default:
        showEnrollFPIcon(String("      ERROR"), RED, 2);
        Serial.println("Unknown error");
        writeicon = true;
        goto ENROLLLOOP;
    }
    
    // OK converted!
    Serial.print("Creating model for #");  Serial.println(fingerprintID);
  
    p = finger.createModel();
    if (p == FINGERPRINT_OK) {
      showEnrollFPIcon(String("  Prints matched!"), GREEN, 2);
    } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
      showEnrollFPIcon(String("      ERROR"), RED, 2);
      Serial.println("Communication error");
      writeicon = true;
      goto ENROLLLOOP;
    } else if (p == FINGERPRINT_ENROLLMISMATCH) {
      showEnrollFPIcon(String("      ERROR"), RED, 2);
      Serial.println("Fingerprints did not match");
      writeicon = true;
      goto ENROLLLOOP;
    } else {
      showEnrollFPIcon(String("      ERROR"), RED, 2);
      Serial.println("Unknown error");
      writeicon = true;
      goto ENROLLLOOP;
    }   
  
    p = finger.storeModel(fingerprintID);
    if (p == FINGERPRINT_OK) {      
      showEnrollFPIcon(String("     Stored!"), GREEN, 2);
      switch(type_enroll) {
        case TStudent: {
          Student *student = students[index_enroll];          
          student->fingerprint = fingerprintID;
          writeStudents(students);
          break;
        } case TStaff: {
          Staff *staff = staffs[index_enroll];
          staff->fingerprint = fingerprintID;
          writeStaffs(staffs);
          break;
        }
      }
    } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
      showEnrollFPIcon(String("      ERROR"), RED, 2);
      Serial.println("Communication error");
      writeicon = true;
      goto ENROLLLOOP;
    } else if (p == FINGERPRINT_BADLOCATION) {
      showEnrollFPIcon(String("      ERROR"), RED, 2);
      Serial.println("Could not store in that location");
      writeicon = true;
      goto ENROLLLOOP;
    } else if (p == FINGERPRINT_FLASHERR) {
      showEnrollFPIcon(String("      ERROR"), RED, 2);
      Serial.println("Error writing to flash");
      writeicon = true;
      goto ENROLLLOOP;
    } else {
      showEnrollFPIcon(String("      ERROR"), RED, 2);
      Serial.println("Unknown error");
      writeicon = true;
      goto ENROLLLOOP;
    }

    break; //break while loop
  }
}

int getFingerprintID() {
  uint8_t p = finger.getImage();
  if (p != FINGERPRINT_OK)  return -1;

  p = finger.image2Tz();
  if (p != FINGERPRINT_OK)  return -1;

  p = finger.fingerFastSearch();
  if (p != FINGERPRINT_OK)  return -2;
  
  // found a match!
  Serial.print("Found ID #"); Serial.print(finger.fingerID); 
  Serial.print(" with confidence of "); Serial.println(finger.confidence);
  return finger.fingerID; 
}

void showAuthFPIcon(String msg, uint16_t color, int waitsec) {
  tft.fillRect(10, 120, 220, 200, WHITE);
  tft.drawRect(56, 130, 128, 128, BLACK);

  tft.setCursor(15, 280);
  tft.setTextColor(color); 
  tft.setTextSize(2);
  tft.print(msg);

  tft.drawBitmap(86, 165, fp_icon, 60, 60, color);
  delay(waitsec * 1000);
}

boolean authendicateStaff() {
  boolean staffAvailable = false;
  for (int i = 0; i < staffs.Size(); i++) {
    if (staffs[i]->fingerprint > 0) {
      staffAvailable = true;
      break;
    }
  }

  if (!staffAvailable) return true; // No Staff is Enrolled to Authendicate

  Adafruit_GFX_Button btn_back;

  btn_back.initButton(&tft, 25, 20, 50, 40, BLACK, WHITE, BLACK, "<-", 2);
  
  tft.fillScreen(WHITE);

  btn_back.drawButton(false);

  boolean writeicon = true;

  tft.setCursor(10, 75);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.print("   AUTHENDICATION\n      REQUIRED");

  while (true) {
AUTHLOOP:
    if (writeicon) {
      showAuthFPIcon(String("   Place finger"), BLUE, 0);
      writeicon = false;
    }
    
    bool down = Touch_getXY();

    btn_back.press(down && btn_back.contains(pixel_x, pixel_y));
    
    if (btn_back.justReleased())
        btn_back.drawButton();
    
    if (btn_back.justPressed()) {
        btn_back.drawButton(true);        
        return false;
    }

    fingerprintID = getFingerprintID();
    delay(50);
    if (fingerprintID > 0 && fingerprintID < 101) {
      for (int i = 0; i < staffs.Size(); i++) {
        if (staffs[i]->fingerprint == fingerprintID) {
          showAuthFPIcon(String("  Authendicated!"), GREEN, 2);
          return true;
        }
      }
    } else if (fingerprintID > 100) {
      showAuthFPIcon(String("   Not Allowed!"), RED, 2);
      writeicon = true;
      goto AUTHLOOP;
    }else if (fingerprintID == -2) {
      showAuthFPIcon(String("  Authendication\n       Failed"), RED, 2);
      writeicon = true;
      goto AUTHLOOP;
    }
  }
}

int selectPeriod() {
  Adafruit_GFX_Button btn_back, btn_h1, btn_h2, btn_h3, btn_h4, btn_h5, btn_hA;

  btn_back.initButton(&tft, 25, 20, 50, 40, BLACK, WHITE, BLACK, "<-", 2);
  btn_h1.initButton(&tft, 45, 150, 50, 40, BLACK, WHITE, BLACK, "1", 2);
  btn_h2.initButton(&tft, 95, 150, 50, 40, BLACK, WHITE, BLACK, "2", 2);
  btn_h3.initButton(&tft, 145, 150, 50, 40, BLACK, WHITE, BLACK, "3", 2);
  btn_h4.initButton(&tft, 195, 150, 50, 40, BLACK, WHITE, BLACK, "4", 2);
  btn_h5.initButton(&tft, 45, 190, 50, 40, BLACK, WHITE, BLACK, "5", 2);
  btn_hA.initButton(&tft, 145, 190, 150, 40, BLACK, WHITE, BLACK, "AUTO", 2);

  tft.fillScreen(WHITE);

  tft.setCursor(10, 75);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.print("   SELECT HOUR");

  btn_back.drawButton(false);
  btn_h1.drawButton(false);
  btn_h2.drawButton(false);
  btn_h3.drawButton(false);
  btn_h4.drawButton(false);
  btn_h5.drawButton(false);
  btn_hA.drawButton(false);

  while (true) {
    bool down = Touch_getXY();

    btn_back.press(down && btn_back.contains(pixel_x, pixel_y));
    btn_h1.press(down && btn_h1.contains(pixel_x, pixel_y));
    btn_h2.press(down && btn_h2.contains(pixel_x, pixel_y));
    btn_h3.press(down && btn_h3.contains(pixel_x, pixel_y));
    btn_h4.press(down && btn_h4.contains(pixel_x, pixel_y));
    btn_h5.press(down && btn_h5.contains(pixel_x, pixel_y));
    btn_hA.press(down && btn_hA.contains(pixel_x, pixel_y));
    
    if (btn_back.justReleased())
        btn_back.drawButton();
    if (btn_h1.justReleased())
        btn_h1.drawButton();
    if (btn_h2.justReleased())
        btn_h2.drawButton();
    if (btn_h3.justReleased())
        btn_h3.drawButton();
    if (btn_h4.justReleased())
        btn_h4.drawButton();
    if (btn_h5.justReleased())
        btn_h5.drawButton();
    if (btn_hA.justReleased())
        btn_hA.drawButton();
    
    if (btn_back.justPressed()) {
        btn_back.drawButton(true);        
        return 0;
    }
    if (btn_h1.justPressed()) {
        btn_h1.drawButton(true);        
        return 1;
    }
    if (btn_h2.justPressed()) {
        btn_h2.drawButton(true);        
        return 2;
    }
    if (btn_h3.justPressed()) {
        btn_h3.drawButton(true);        
        return 3;
    }
    if (btn_h4.justPressed()) {
        btn_h4.drawButton(true);        
        return 4;
    }
    if (btn_h5.justPressed()) {
        btn_h5.drawButton(true);        
        return 5;
    }
    if (btn_hA.justPressed()) {
        btn_hA.drawButton(true);
        int hour = RTC.now().hour();
        int minute = RTC.now().minute();
        
        int startHour = 8 + (shift == 1 ? 0 : 5);
        for (int i = 1; i <= 5; i++) {
          if ((hour == startHour + (i - 1) && minute >= 45) || (hour == startHour + i && minute < 45)) {
            return i;
          }
        }
        
        return 5;
    }
  }
}

char* getDate() {
  char* date = "01-01-2019";
  sprintf(date, "%02d-%02d-%04d", RTC.now().day(), RTC.now().month(), RTC.now().year());
  return date;
}

void displayMark(int hour) {
  char* date = getDate();
  Adafruit_GFX_Button btn_back;

  btn_back.initButton(&tft, 25, 20, 50, 40, BLACK, WHITE, BLACK, "<-", 2);
  
  tft.fillScreen(WHITE);

  btn_back.drawButton(false);

  boolean writeicon = true;

  tft.setCursor(10, 65);
  tft.setTextColor(RED);
  tft.setTextSize(2);
  tft.print("  MARK ATTENDANCE");

  tft.setCursor(73, 95);
  tft.setTextColor(GREY);
  tft.setTextSize(1);
  tft.print("Date: ");
  tft.print(date);
  tft.setCursor(73, 105);
  tft.print("Hour: ");
  tft.print(hour);

  while (true) {
AUTHLOOP:
    if (writeicon) {
      showAuthFPIcon(String("   Place finger"), BLUE, 0);
      writeicon = false;
    }
    
    bool down = Touch_getXY();

    btn_back.press(down && btn_back.contains(pixel_x, pixel_y));
    
    if (btn_back.justReleased())
        btn_back.drawButton();
    
    if (btn_back.justPressed()) {
        btn_back.drawButton(true);        
        return false;
    }

    fingerprintID = getFingerprintID();
    delay(50);
    if (fingerprintID > 0 && fingerprintID < 101) {
      for (int i = 0; i < staffs.Size(); i++) {
        if (staffs[i]->fingerprint == fingerprintID) {
          showAuthFPIcon(String("  Authendicated!"), GREEN, 2);
          return true;
        }
      }
    } else if (fingerprintID > 100) {
      showAuthFPIcon(String("   Not Allowed!"), RED, 2);
      writeicon = true;
      goto AUTHLOOP;
    }else if (fingerprintID == -2) {
      showAuthFPIcon(String("  Authendication\n       Failed"), RED, 2);
      writeicon = true;
      goto AUTHLOOP;
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

  // Fingerprint
  finger.begin(57600);
  
  if (finger.verifyPassword()) {
    Serial.println("Found fingerprint sensor!");
  } else {
    Serial.println("Did not find fingerprint sensor :(");    
  }

  Wire.begin();
  RTC.begin();
  if (! RTC.isrunning()) {
    Serial.println("RTC is NOT running!");
    RTC.adjust(DateTime(__DATE__, __TIME__));
  }
}

void loop() {  
  displayHome();

  if (display_enroll) {
    display_enroll = false;
    if (authendicateStaff()) {
      displaySelectType();
    }
  }

  if (display_mark) {
    display_mark = false;
    if (authendicateStaff()) {
      int period = selectPeriod();
      if (period > 0) {
        displayMark(period);
      }
    }
  }
}
