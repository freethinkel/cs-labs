using System;

namespace lab1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      var smirnov = new HeadOfDepartment();
      smirnov.Walk();
      string a = Console.ReadLine();
      Console.WriteLine(a);
    }
  }


  interface Person
  {
    void Walk() { }
  }

  class HeadOfDepartment : Person
  {
    void Walk()
    {
      Console.WriteLine("im walk!");
    }
  }

  class Teacher
  {

  }

  class Student { }

}
