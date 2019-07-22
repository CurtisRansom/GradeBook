using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {

        private List<double> _grades;
        private string _name;

        public Book(string name)
        {
            _grades = new List<double>();
            this._name = name;
        }

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public void ShowStatistics()
        {
            double result = 0.0;
            double highGrade = double.MinValue;
            double lowGrade = double.MaxValue;

            // Loop through all the grades to find the lowest, highest and sum
            foreach(var number in _grades)
            {
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }

            // Compute the average
            result /= _grades.Count;

            // Output the results
            Console.WriteLine($"The lowest grade is {lowGrade}.");
            Console.WriteLine($"The highest grade is {highGrade}.");
            Console.WriteLine($"The average grade is {result:N1}.");
        }

    }

}