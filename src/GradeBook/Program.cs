using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Livro de notas do Matheus");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Para o nome do livro {book.Name}");
            Console.WriteLine($"A menor nota e {stats.Low}");
            Console.WriteLine($"A maior nota e {stats.High}");
            Console.WriteLine($"A média das notas são {stats.Average:N1}");
            Console.WriteLine($"A nota e {stats.letter}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Coloque sua nota ou 'q' para pular");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Uma nota foi adicionada");
        }



    }
}
