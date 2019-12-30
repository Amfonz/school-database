using System;
namespace school_db {
  class DateGenerator {
    int year;
    public DateGenerator(int year) {
      this.year = year;
    }

    private int getRandomStudentYear() {
      //return random year within 4 years of year
      Random rand = new Random();
      return year + rand.Next(0,4);
    }

    private int getRandomTeacherYear() {
      //return random year within 4 years of year
      Random rand = new Random();
      return year + rand.Next(0,10);
    }

    public void setYear(int year) {
      this.year = year;
    }
    public string getRandomDate(string type) {
      Random rand = new Random();
      string year;
      if (type == "student") {
        year = getRandomStudentYear().ToString();

      }else {
        year = getRandomTeacherYear().ToString();
      }
      string month = rand.Next(1,13).ToString("D2");
      string day;
      switch (Int32.Parse(month)) {
        case 1:
        case 3:
        case 5:
        case 7:
        case 8:
        case 10:
        case 12:
          day = rand.Next(1,32).ToString("D2");
          break;
        
        case 4:
        case 6:
        case 9: 
        case 11:
          day = rand.Next(1,31).ToString("D2");
          break;
        default:
          day = rand.Next(1,29).ToString("D2");
          break;
      }
      return $"{year}-{month}-{day}";
    } // end randomDate
  }// end class
}