using System;

namespace school_db {
  class Program {

      const int teacherRecords = 35;
      const int studentRecords = 200;
    static void Main(string[] args) {
      DepartmentStaffRecordGenerator dsGen = new DepartmentStaffRecordGenerator(teacherRecords);
      dsGen.generateRecords();
      dsGen.writeSQLToFile();

      StaffPurchaseRecordGenerator spGen = new StaffPurchaseRecordGenerator(50,teacherRecords);
      spGen.generateRecords();
      spGen.writeSQLToFile();

      LockerRecordGenerator lGen = new LockerRecordGenerator(studentRecords);
      lGen.generateRecords();
      lGen.writeSQLToFile();

      TeacherRecordGenerator tGen = new TeacherRecordGenerator(teacherRecords);
      tGen.generateRecords();
      tGen.writeSQLToFile();

      StudentRecordGenerator sGen = new StudentRecordGenerator(studentRecords);
      sGen.generateRecords();
      sGen.writeSQLToFile();
    }
  
  }
}
