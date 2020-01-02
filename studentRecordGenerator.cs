using System;
using System.IO;
namespace school_db {
  class StudentRecordGenerator {
    DateGenerator dGen = new DateGenerator(2016);
    NameGenerator nGen = new NameGenerator();

    string[] records;
    int numberOfRecords;
  
    public StudentRecordGenerator(int numberOfRecords){
      this.numberOfRecords = numberOfRecords;
      this.records = new string[numberOfRecords];
    }

    public void generateRecords() {
      Random rand = new Random();
      for(int i = 0; i < numberOfRecords; i++){
        string firstName = nGen.getRandomName();
        string lastName = nGen.getRandomName();
        string date = dGen.getRandomDate("student");
        int lockerNumber = rand.Next(1,numberOfRecords+1);
        string sql = $"INSERT INTO STUDENTS(FIRST_NAME,LAST_NAME,DATE_OF_BIRTH,LOCKER_NUMBER) VALUES ('{firstName}','{lastName}','{date}',{lockerNumber});";
        this.records[i] = sql;
      }
    }

    public void writeSQLToFile() {
      try{
        using (StreamWriter sr = new StreamWriter("student-records.sql")) {
          sr.WriteLine("USE school");
          foreach (var record in records){
            sr.WriteLine(record);
          }
        }
      }
      catch(Exception e) {
        Console.WriteLine("Could not write to file");
      }
    }
  }//end class
}