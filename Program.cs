using System;

namespace school_db {
  class Program {
    static void Main(string[] args) {
      StudentRecordGenerator sGen = new StudentRecordGenerator(100);
      sGen.generateRecords();
      sGen.writeSQLToFile();
    }
  
  }
}
