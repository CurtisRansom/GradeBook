using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        private List<double> _grades;
        private string _name;
        
        // Constructor
        public Book(string name)
        {
            _grades = new List<double>();
            this._name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void AddLetterGrade(char letter)
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
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(50);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >=0 && grade <= 100)
            {
                _grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            // Loop through all the grades to find the lowest, highest and sum
            foreach(var grade in _grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }

            // Compute the average
            result.Average /= _grades.Count;

            // Compute letter grade
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

    }

}