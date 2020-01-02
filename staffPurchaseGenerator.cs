using System;
using System.IO;
using System.Collections.Generic;

namespace school_db {
  class StaffPurchaseRecordGenerator {
    int numberOfRecords;
    int teachers;
    string[] records;

    Dictionary<string,double> items = new Dictionary<string,double>();


    public StaffPurchaseRecordGenerator(int numberOfRecords, int teacherRecords) {
      this.numberOfRecords = numberOfRecords;
      records = new string[numberOfRecords];
      teachers = teacherRecords;
      fillItems();
    }

    private void fillItems() {
      items["Comupter"] = 999.99;
      items["Software"] = 90.67;
      items["Chalk"] = 34.44;
      items["Markers"] = 43.45;
      items["Textbook"] = 80.99;
      items["DVD"] = 20.99;
      items["Basketball"] = 20.11;
      items["Football"] = 10.99;
      items["Paper"] = 34.39;
      items["Printer"] = 200.32;
    }
    private string getRandomItem() {
      Random rand = new Random();
      int stop = rand.Next(0,10);
      int i = 0;
      foreach (string key in items.Keys) {
        if (i == stop) {
          return key;
        }else {
          i++;
        }
      }
      return "";
    }//end method

    public void generateRecords() {
      Random rand = new Random();
      for(int i = 0; i < numberOfRecords; i++) {
        int teacherID = rand.Next(1,teachers+1);
        string item = getRandomItem();
        double price = items[item];
        int amount = rand.Next(1,11);

        string record = $"INSERT INTO STAFF_PURCHASE(ID,ITEM,PRICE,AMOUNT) VALUES ({teacherID.ToString()},'{item}',{price.ToString()},{amount.ToString()});";

        records[i] = record;
      }
    }

    public void writeSQLToFile(){
      try {
        using (StreamWriter sw = new StreamWriter("staffPurchase-records.sql")) {
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