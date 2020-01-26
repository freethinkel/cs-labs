using System;
using System.Collections.Generic;

namespace lab3
{
  class Program
  {
    static void Main(string[] args)
    {
      Student[] students = { };
      Institute kgeu = new Institute("КГЭУ");
      while (true)
      {
        string[] globalCommands = {
          "Выйти из программы",
          "Добавить студента",
          "Удалить или заменить студента",
          "Вывести все"
        };
        int num = Program.GetCommandsNumberSync(globalCommands);
        if (num == 0)
        {
          break;
        }
        else if (num == 1)
        {
          kgeu.addStudent(Student.CreateStudent(kgeu));
        }
        else if (num == 2)
        {
          string[] c = { "Удалить", "Заменить" };
          int _num = Program.GetCommandsNumberSync(c);
          if (_num == 0)
          {
            kgeu.RemoveStudent();
          }
        }
        else if (num == 3)
        {
          kgeu.ShowInfo();
        }
        else
        {
          Console.WriteLine("Комманда не найдена \n\n\n\n\n\n");
        }
      }
    }

    static int GetCommandsNumberSync(string[] commands)
    {
      for (int i = 0; i < commands.Length; i++)
      {
        Console.WriteLine("[" + i + "]   " + commands[i]);
      }
      Console.Write("Выберите комманду: ");
      int num = -1;
      try
      {
        num = Convert.ToInt32(Console.ReadLine());
      }
      catch
      {
        Console.WriteLine("Введите число");
      }
      return num;
    }
  }

  class Institute
  {
    List<Student> students = new List<Student>();
    string name;

    public Institute(string name)
    {
      this.name = name;
    }

    public Institute(string name, List<Student> students)
    {
      this.name = name;
      this.students = students;
    }

    public void addStudent(Student s)
    {
      this.students.Add(s);
    }

    public void RemoveStudent(string lastName)
    {
      // this.students.RemoveAll()
    }

    public void ShowInfo()
    {
      Console.WriteLine(this.name);
      Console.WriteLine("---Студенты---");
      this.students.ForEach((s) =>
      {
        Console.WriteLine("==========================");
        s.ShowInfo();
        Console.WriteLine("==========================");
      });
      Console.WriteLine("--------------");
    }

  }

  class Course
  {
    string name;
    public Course(string name)
    {
      this.name = name;
    }
  }

  class Student
  {
    string lastName;
    Institute institute;
    int yearOfStudy;
    string group;
    int[] scores;

    public static Student CreateStudent(Institute inst)
    {
      Console.Write("Фамиллия: ");
      string lastname = Console.ReadLine();
      Console.Write("Группа: ");
      string group = Console.ReadLine();
      Console.Write("Курс: ");
      int yearOfStudy = Convert.ToInt16(Console.ReadLine());
      Console.Write("Оценки: ");
      string _scores = Console.ReadLine();
      int[] scores = Array.ConvertAll(_scores.Split(" "), int.Parse);
      return new Student(lastname, group, inst, yearOfStudy, scores);
    }
    public Student(string lastName, string group, Institute institute, int yearOfStudy, int[] scores)
    {
      this.lastName = lastName;
      this.group = group;
      this.institute = institute;
      this.yearOfStudy = yearOfStudy;
      this.scores = scores;
    }

    public void ShowInfo()
    {
      Console.WriteLine("Фамиллия: " + this.lastName);
      Console.WriteLine("Группа: " + this.group);
      Console.WriteLine("Курс: " + this.yearOfStudy);
      string _scores = "";
      foreach (int s in this.scores)
      {
        _scores += s.ToString() + " ";
      }
      _scores = _scores.Substring(0, _scores.Length - 2);
      Console.WriteLine("Оценки: " + _scores);
    }
  }
}
