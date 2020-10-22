using System;
using System.Collections.Generic;
namespace GradeBook
{
   class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
             var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var number in grades)
            {
                lowGrade =  Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }
            result /= grades.Count;
            Console.WriteLine($"A menor nota e {lowGrade}");
            Console.WriteLine($"A maior nota e {highGrade}");
            Console.WriteLine($"A média das notas são {result:N1}");                  
        }

        private List<double> grades;
        private string name;
    }
}