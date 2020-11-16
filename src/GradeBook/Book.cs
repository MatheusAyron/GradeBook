using System;
using System.Collections.Generic;
namespace GradeBook
{
    public delegate void GradeAddDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public string Name
        {
            get;
            set;
        }
    }

    public class Book : NamedObject
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break; 

                default:
                    AddGrade(0);
                    break;         
            }
        }




        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {               
                grades.Add(grade);
                if(GradeAdded != null)
                {
                   GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Valor {nameof(grade)} inválido");
            }
            
        }

        public event GradeAddDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(var index = 0; index < grades.Count; index +=1)
            {        
                result.Low =  Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }

            result.Average /= grades.Count; 

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;   

                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;   

                case var d when d >= 60.0:
                    result.letter = 'D';
                    break;

                default:
                    result.letter = 'C';
                    break;        

            }



            return result;               
        }

        private List<double> grades;
        public const string CATEGORY = "Ciências";
    }
}