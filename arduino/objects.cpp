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

void writeStudents(Vector<Student*> students) {
  File dataFile;

  Serial.println("Writing Students Data...");
  dataFile = SD.open("students", O_WRITE | O_CREAT | O_TRUNC);
  if (dataFile) {
    for (int i = 0; i < students.Size(); i++) {
      Student* student = students[i];
      dataFile.print(student->id);
      dataFile.print(";");
      dataFile.print(student->regno);
      dataFile.print(";");
      dataFile.print(student->name);
      dataFile.print(";");
      dataFile.println(student->fingerprint);
    }
    dataFile.close();
  } else {
    Serial.println("Unable to open students file for writing..!");
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

void writeStaffs(Vector<Staff*> staffs) {
  File dataFile;

  Serial.println("Writing Staffs Data...");
  dataFile = SD.open("staffs", O_WRITE | O_CREAT | O_TRUNC);
  if (dataFile) {
    for (int i = 0; i < staffs.Size(); i++) {
      Staff* staff = staffs[i];
      dataFile.print(staff->id);
      dataFile.print(";");
      dataFile.print(staff->name);
      dataFile.print(";");
      dataFile.println(staff->fingerprint);      
    }
    dataFile.close();
  } else {
    Serial.println("Unable to open staffs file for writing..!");
  }
}

void readAttendance(Attendance *attendance, Vector<Student*> students) {
  char filename[12];
  String date = String(attendance->date);
  date.replace("-","");
  date.remove(4, 2);
  sprintf(filename, "%s_%d", date.c_str(), attendance->hour);
  Serial.print("Attempting to read attendance: ");
  Serial.println(filename);

  delay(1000);

  if (SD.exists(filename)) {
    Serial.println("Attendance exists... Reading..!");
    File dataFile;
    String buffer;

    int line = 0;
    dataFile = SD.open(filename);
    if (dataFile) {
      while (dataFile.available()) {
        buffer = dataFile.readStringUntil('\n');

        if (line > 0) {
          int id = -1;
          int status_ = 0;
          enum attstatus status = Absent;
          
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
                status_ = atoi(str);
                if (status_ == 1)
                  status = Present;
                else
                  status = Absent;
                break;
            }
            index += 1;
          }
          if (id > 0) {
            AttendanceItem* item = new AttendanceItem(id, status);
            attendance->items.PushBack(item);
          }
        }
        line += 1;
      }
      dataFile.close();
      Serial.print("Successfully parsed ");
      Serial.print(attendance->items.Size());
      Serial.println(" attendance items...");
    } else {
      Serial.println("Unable to open attendance file..!");
    }
  } else {
    Serial.println("Attendance doesn't exist... Creating..!");
    for (int i = 0; i < students.Size(); i++) {
      AttendanceItem* item = new AttendanceItem(students[i]->id, Absent);
      attendance->items.PushBack(item);
    }
    Serial.print("Successfully created ");
    Serial.print(attendance->items.Size());
    Serial.println(" attendance items...");
  }
}

void writeAttendance(Attendance *attendance) {
  char filename[12];
  String date = String(attendance->date);
  date.replace("-","");
  date.remove(4, 2);
  sprintf(filename, "%s_%d", date.c_str(), attendance->hour);
  File dataFile;

  int present = 0;
  int absent = 0;
  Serial.println("Writing Attendance Data...");
  dataFile = SD.open(filename, O_WRITE | O_CREAT | O_TRUNC);
  if (dataFile) {
    dataFile.println(attendance->staffID);
    for (int i = 0; i < attendance->items.Size(); i++) {
      AttendanceItem* item = attendance->items[i];
      dataFile.print(item->id);
      dataFile.print(";");
      if (item->status == Present) {
        dataFile.println(1);
        present += 1;
      } else {
        dataFile.println(0);
        absent += 1;
      }
    }
    dataFile.close();
    Serial.print("Saving Attendance! Present :");
    Serial.print(present);
    Serial.print(" Absent:");
    Serial.println(absent);
  } else {
    Serial.println("Unable to open attendance file for writing..!");
  }
}
