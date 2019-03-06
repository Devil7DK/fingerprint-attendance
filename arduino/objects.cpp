#include <SPI.h>
#include <SD.h>

#include "Vector.h"

#include "objects.h"

String readPrefix() {
  File prefixFile;
  prefixFile = SD.open("prefix");
  if (prefixFile) {
    while (prefixFile.available()) {
      return prefixFile.readStringUntil('\n');
    }
  } else {
    Serial.println("Unable to open prefix file..!");
    return "";
  }
}

void readData(Vector<Person*> *persons) {
  File dataFile;
  String buffer;

  Serial.println("Reading Persons Data...");
  dataFile = SD.open("persons");
  if (dataFile) {
    while (dataFile.available()) {
      buffer = dataFile.readStringUntil('\n');

      int id = -1;
      String regno = "";
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
            regno = str;
            break;
          case 2:
            name = str;
            break;
          case 3:
            type = atoi(str);
            break;
          case 4:
            fingerprint = atoi(str);
            break;
        }
        index += 1;
      }
      if (id > 0) {
        Person* person = new Person(id, regno, name, type, fingerprint);
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
