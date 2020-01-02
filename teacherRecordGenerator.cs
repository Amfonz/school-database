using System;
using System.IO;
namespace school_db {
  class TeacherRecordGenerator {
    DateGenerator dGen = new DateGenerator(1990);
    NameGenerator nGen = new NameGenerator();

    string[] records;

    int numberOfRecords;

    public TeacherRecordGenerator(int numberOfRecords) {
      this.numberOfRecords = numberOfRecords;
      records = new string[numberOfRecords];
    }

    public void generateRecords() {
      Random rand = new Random();
      for(int i = 0; i < numberOfRecords; i++){
        string firstName = nGen.getRandomName();
        string lastName = nGen.getRandomName();
        string date = dGen.getRandomDate("teacher");
        int salary = rand.Next(40000,100001);
        string sql = $"INSERT INTO TEACHERS(FIRST_NAME,LAST_NAME,EMPLOYMENT_START,SALARY) VALUES ('{firstName}','{lastName}','{date}',{salary});";
        this.records[i] = sql;
      }
    }

    public void writeSQLToFile() {
      try{
        using (StreamWriter sr = new StreamWriter("teacher-records.sql")) {
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
  }
}