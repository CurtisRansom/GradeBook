using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    // Inheritance
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set;}
    }

    public interface IBook
    {
        string Name { get;}

        void AddGrade(double grade);

        Statistics GetStatistics();

        event GradedAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradedAddedDelegate GradeAdded;

        // *** Abstract - Must be implemented
        public abstract void AddGrade(double grade);

        // *** Virtual - Can be implemented, but not necessary
        public abstract Statistics GetStatistics();
    }

    public delegate void GradedAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {
        private List<double> _grades;
        readonly string _school = string.Empty;

        public const string CATEGORY = "Science";
 
        // Constructor
        public InMemoryBook(string name) : base(name)
        {
            _grades = new List<double>();
            _school = "South County";
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
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(50);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade >=0 && grade <= 100)
            {
                _grades.Add(grade);

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override event GradedAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            // Loop through all the grades to find the lowest, highest and sum
            foreach(var grade in _grades)
            {
                result.Add(grade);
            }           

            return result;
        }

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradedAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            // *** Using statement makes sure that .Dispose() is called
            using (StreamWriter sw = File.AppendText($"{Name}.txt"))
            {
                sw.WriteLine(grade);     

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }           
            }
     

        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (StreamReader sr = File.OpenText($"{Name}.txt"))
            {
                string line = sr.ReadLine();

                while(line != null)
                {
                    double number = double.Parse(line);
                    result.Add(number);
                    line = sr.ReadLine();
                }
            }

            return result;
        }
    }


}