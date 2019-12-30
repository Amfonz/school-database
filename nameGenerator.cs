using System;
using System.IO;
namespace school_db {
  class NameGenerator {
    string[] names = new string[200];
    public NameGenerator() {
      loadNames();
    }
    private void loadNames() {
      try{
        using (StreamReader sr = new StreamReader("names.csv")) {
          sr.BaseStream.Seek(0,SeekOrigin.Begin);
          string line;
          int index = 0;
          while ((line = sr.ReadLine()) != null) {
            this.names[index] = line.Split(',')[2];
            index++;
          }
        }
      }
      catch(Exception e) {
        Console.WriteLine("Could not read from file");
      }
    } 
    public string getRandomName() {
      Random rand = new Random();
      return names[rand.Next(0,200)];
    }
  }// end class
}