using System;
using System.IO;
namespace school_db {
  class LockerRecordGenerator {

    string[] records;

    int numberOfRecords;

    public LockerRecordGenerator(int numberOfRecords) {
      records = new string[numberOfRecords];
      this.numberOfRecords = numberOfRecords;
    }

    private int[] generateCombination() {
      Random rand = new Random();
      int[] combination = {rand.Next(1,255),rand.Next(1,256),rand.Next(1,256)};
      return combination;
    }
    public void generateRecords() {
      for(int i = 1; i <= numberOfRecords; i++){
        int[] combination = generateCombination();

        string record = $"INSERT INTO LOCKERS(COMBINATION_1,COMBINATION_2,COMBINATION_3) VALUES ({combination[0].ToString()},{combination[1].ToString()},{combination[2].ToString()});";

        records[i-1] = record;
      }
    }
    public void writeSQLToFile(){
      try {
        using (StreamWriter sw = new StreamWriter("locker-records.sql")) {
          sw.WriteLine("USE school");
          foreach (var record in records){
            sw.WriteLine(record);
          }
        }
      }
      catch(Exception e) {
        Console.WriteLine("Could not write to file");
      }
    }

  }
}