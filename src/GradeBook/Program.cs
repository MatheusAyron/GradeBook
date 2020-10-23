using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Livro de notas do Matheus");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            
            var stats = book.GetStatistics();
            Console.WriteLine($"A menor nota e {stats.Low}");
            Console.WriteLine($"A maior nota e {stats.High}");
            Console.WriteLine($"A média das notas são {stats:N1}");  

        }
    }
}
