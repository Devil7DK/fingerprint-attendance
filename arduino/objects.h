#include <SPI.h>
#include <SD.h>

#include "Vector.h"

enum types {TStaff, TStudent};

class Student {
  public:
    int id;
    String regno;
    String name;
    int fingerprint;

  Student() {
    id = -1;
    regno = "00";
    name = "";
    fingerprint = -1;
  }
  
  Student(int id_, String regno_, String name_, int fingerprint_) {
    id = id_;
    regno = regno_;
    name = name_;
    fingerprint = fingerprint_;
  }
};

class Staff {
  public:
    int id;
    String name;
    int fingerprint;

  Staff() {
    id = -1;
    name = "";
    fingerprint = -1;
  }
  
  Staff(int id_, String name_, int fingerprint_) {
    id = id_;
    name = name_;
    fingerprint = fingerprint_;
  }
};

String readPrefix();
int readShift();
void readStudents(Vector<Student*> *students);
void writeStudents(Vector<Student*> students);
void readStaffs(Vector<Staff*> *staffs);
void writeStaffs(Vector<Staff*> staffs);
