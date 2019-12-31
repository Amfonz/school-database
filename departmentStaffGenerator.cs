using System;
using System.IO;

namespace school_db {
  class DepartmentStaffRecordGenerator {
    int numberOfRecords;
    string[] records;
    public DepartmentStaffRecordGenerator(int numberOfRecords) {
      this.numberOfRecords = numberOfRecords;
      records = new string[numberOfRecords];
    }

    private string getRandomDepartment() {
      Random rand = new Random();
      string[] departments = {"Science","Art","Math","English","Tech","History","Geography","Phys-Ed"};
      return departments[rand.Next(0,departments.Length)];
    }

    public void generateRecords() {
      for(int i = 1; i <= numberOfRecords; i++) {
        string record = $"INSERT INTO DEPARTMENT_STAFF(DEPARTMENT_NAME,ID) VALUES ('{getRandomDepartment()}',{i.ToString()})";
        records[i-1] = record;
      }
    }

    public void writeSQLToFile() {
      try {
        using(StreamWriter sw = new StreamWriter("departmentStaff-records.sql")) {
            sw.WriteLine("USE school");
            foreach (var record in records) {
              sw.WriteLine(record);
            }
          }
      }
      catch (Exception e) {
        Console.WriteLine("Could not write to file");
      }
    }
  }
}