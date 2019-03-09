#include <SPI.h>
#include <SD.h>

#include "Vector.h"

enum types {TStaff, TStudent};
enum attstatus {Present, Absent};

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

class AttendanceItem {
  public:
    int id;
    enum attstatus status;

  AttendanceItem(int id_, enum attstatus status_) {
    id = id_;
    status = status_;
  }
};

class Attendance {
  public:
    int staffID;
    char* date;
    int hour;
    Vector<AttendanceItem*> items;

  Attendance() {
    staffID = -1;
    date = "01-09-2019";
    hour = 1;
  }

  Attendance(int staffID_, char* date_, int hour_) {
    staffID = staffID_;
    date = date_;
    hour = hour_;
  }
};

String readPrefix();
int readShift();
void readStudents(Vector<Student*> *students);
void writeStudents(Vector<Student*> students);
void readStaffs(Vector<Staff*> *staffs);
void writeStaffs(Vector<Staff*> staffs);

void readAttendance(Attendance *attendance, Vector<Student*> students);
void writeAttendance(Attendance *attendance);
