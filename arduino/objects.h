#include <SPI.h>
#include <SD.h>

#include "Vector.h"

enum types {Staff, Student};

class Person {
  public:
    int id;
    String name;
    enum types type;
    int fingerprint;

  Person() {
    id=-1;
    name="";
    type=Staff;
  }
  
  Person(int id_, String name_, int type_, int fingerprint_) {
    id=id_;
    name=name_;
    switch(type_) {
      case 0:
        type=Staff;
        break;
      case 1:
        type=Student;
        break;
    }
    fingerprint=fingerprint_;
  }
};

void readData(Vector<Person*> persons);
