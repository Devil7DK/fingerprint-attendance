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

int readShift() {
  File shiftFile;
  shiftFile = SD.open("shift");
  if (shiftFile) {
    while (shiftFile.available()) {
      return shiftFile.readStringUntil('\n').toInt();
    }
  } else {
    Serial.println("Unable to open shift file..!");
    return 1;
  }
}

void readStudents(Vector<Student*> *students) {
  File dataFile;
  String buffer;

  Serial.println("Reading Students Data...");
  dataFile = SD.open("students");
  if (dataFile) {
    while (dataFile.available()) {
      buffer = dataFile.readStringUntil('\n');

      int id = -1;
      String regno = "";
      String name = "";
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
            fingerprint = atoi(str);
            break;
        }
        index += 1;
      }
      if (id > 0) {
        Student* student = new Student(id, regno, name, fingerprint);
        students->PushBack(student);
      }
    }
    dataFile.close();
    Serial.print("Successfully parsed ");
    Serial.print(students->Size());
    Serial.println(" students...");
  } else {
    Serial.println("Unable to open students file..!");
  }
}


void readStaffs(Vector<Staff*> *staffs) {
  File dataFile;
  String buffer;

  Serial.println("Reading Staffs Data...");
  dataFile = SD.open("staffs");
  if (dataFile) {
    while (dataFile.available()) {
      buffer = dataFile.readStringUntil('\n');

      int id = -1;
      String regno = "";
      String name = "";
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
            fingerprint = atoi(str);
            break;
        }
        index += 1;
      }
      if (id > 0) {
        Staff* staff = new Staff(id, name, fingerprint);
        staffs->PushBack(staff);
      }
    }
    dataFile.close();
    Serial.print("Successfully parsed ");
    Serial.print(staffs->Size());
    Serial.println(" staffs...");
  } else {
    Serial.println("Unable to open staffs file..!");
  }
}
