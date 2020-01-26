using System;

namespace lab2
{
  class Program
  {
    static void Main(string[] args)
    {
      string universityName = "КГЭУ";
      string departament = "Инженерная кибернетика";
      Person smirnow = new HeadOfDepartament("Юрий Николаевич", 65, universityName, departament, 39);
      Person ali = new Teacher("Али Анварович", 68, universityName, departament, 37);
      Person egor = new Student("Егор Леонидович", 21, universityName, departament, 4);
      
      smirnow.ShowInfo();
      smirnow.ShowPosition(new Time(12, 00, 00));
      smirnow.Walk();
     
      ali.ShowInfo();
      ali.ShowPosition(new Time(12, 00, 00));
      ali.Walk();
      
      egor.ShowInfo();
      egor.ShowPosition(new Time(12, 00, 00));
      egor.Walk();
    }
  }

  abstract class Person: IBelongsToIniversity, IWalk, IPosition
  {
    public string name;
    public int age {get;set;}
    public int yearsOfUniversity {get;set;}
    public string universityName {get;set;}
    public string departament {get;set;}
    public Person(string name, int age, int yearsOfUniversity, string universityName, string departament) {
      this.name = name;
      this.age = age;
      this.yearsOfUniversity = yearsOfUniversity;
      this.universityName = universityName;
      this.departament = departament;
    }

    public virtual void Walk() {
      Console.WriteLine("Иду...");
    }

    public virtual void ShowPosition(Time currentTime) {
      if (currentTime.h > 23 && currentTime.h < 8) {
        Console.WriteLine("Zzzz");
      } else {
        Console.WriteLine("Бодрствую...");
      }
    }

    public void ShowInfo() {
      Console.WriteLine("-----------");
      Console.WriteLine("Имя: " + this.name);
      Console.WriteLine("Возраст "+ this.age);
      Console.WriteLine("ВУЗ: " + this.universityName); 
      Console.WriteLine("Кафедра: " + this.departament);
      Console.WriteLine("Лет в вузе: " + this.yearsOfUniversity);
      Console.WriteLine("-----------");
    }
  }

  class HeadOfDepartament : Person
  {
    public HeadOfDepartament(string name, int age, string universityName, string departament, int yearsOfUniversity): 
      base(name, age, yearsOfUniversity, universityName, departament ) {}
  }

  class Teacher: Person
  {
    public Teacher(string name, int age, string universityName, string departament, int yearsOfUniversity): 
      base(name, age, yearsOfUniversity, universityName, departament ) {}
  }

  class Student: Person {
    public Student(string name, int age, string universityName, string departament, int yearsOfUniversity): 
      base(name, age, yearsOfUniversity, universityName, departament ) {}

    public override void ShowPosition(Time currentTime) {
      if (currentTime.h < 8 && currentTime.h > 22) {
        Console.WriteLine("Zzzzz");
      } else if (currentTime.h > 9 && currentTime.h < 18) {
        Console.WriteLine("На учебе");
      } else {
        Console.WriteLine("Дома");
      }
    }

  }

  public class Time {
    public int h;
    public int m;
    public int s = 0;
    public Time(int h, int m, int s) {
      this.h = h;
      this.m = m;
      this.s = s;
    }

    public int getTime() {
      return this.h*this.m*this.s;
    }
  }


  public interface IBelongsToIniversity {
    int yearsOfUniversity {get; set;}
    string universityName {get; set;}
    string departament {get; set;}
  }

  public interface IWalk {
    void Walk();
  }

  public interface IPosition {
    void ShowPosition(Time currentTime);
  }
  
}

