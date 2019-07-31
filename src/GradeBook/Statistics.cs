using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                if(Count > 0)
                {
                    return Sum/Count;
                }
                else
                {
                    return 0;
                }
                
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {

                 // Compute letter grade
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';
                        
                    default:
                        return 'F';
                }
            }
        }

        public double Sum;

        public int Count;

        public Statistics()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double number)
        {
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
            Sum += number;
            Count += 1;
        }

        public Statistics(List<double> grades)
        {
        }
    }
}