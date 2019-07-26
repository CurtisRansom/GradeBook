using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {

        static void OnGradeAded(object sender, EventArgs arg)
        {
            Console.WriteLine("A grade was added.");
        }

        static void Main(string[] args)
        {       
            var book = new Book("Curtis's Grade Book");
            book.GradedAdded += OnGradeAded;

            while (true)
            {
                Console.WriteLine("Enter a grade or type 'q' to commute.");
                var input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                     Console.WriteLine(ex.Message);
                }           
                 
            } 

            var stats = book.GetStatistics();

            // Output the results
            Console.WriteLine();
            Console.WriteLine($"For the gradebook named {book.Name}");
            Console.WriteLine($"The category of the grades is {Book.CATEGORY}");
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The average grade is {stats.Average:N1}.");
            Console.WriteLine($"The letter grade is {stats.Letter}.");
        }
    }

    
}
