#include <SPI.h>
#include <SD.h>

#include "Vector.h"

#include "objects.h"

void readData(Vector<Person*> *persons) {
  File dataFile;
  String buffer;

  Serial.println("Reading Persons Data...");
  dataFile = SD.open("persons");
  if (dataFile) {
    while (dataFile.available()) {
      buffer = dataFile.readStringUntil('\n');

      int id = -1;
      String name = "";
      int type = 0;
      int fingerprint = -1;
      
      int index = 0;
      char buf[buffer.length()];
      buffer.toCharArray(buf, sizeof(buf));
      char *p = buf;
      char *str;
      while ((str = strtok_r(p, ";", &p)) != NULL) {
        switch(index) {
          case 0:
            id = atoi(str);
            break;
          case 1:
            name = str;
            break;
          case 2:
            type = atoi(str);
            break;
          case 3:
            fingerprint = atoi(str);
            break;
        }
        index += 1;
      }
      if (id > 0) {
        Person* person = new Person(id, name, type, fingerprint);
        persons->PushBack(person);
      }
    }
    dataFile.close();
    Serial.print("Successfully parsed ");
    Serial.print(persons->Size());
    Serial.println(" persons...");
  } else {
    Serial.println("Unable to open persons file..!");
  }
}
