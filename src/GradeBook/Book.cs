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

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
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

            return result;
        }

    }

}