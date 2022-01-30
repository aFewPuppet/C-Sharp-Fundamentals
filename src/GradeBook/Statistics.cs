using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum/count;
            }
        }
        public double High, Low, Sum;
        public int count;
        public char letterGrade
        {
            get
            {
                switch(Average)
            {
                case var d when d >= 90.0:
                return'A';
                
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

        public Statistics()
        {
            
            High = double.MinValue;
            Low = double.MaxValue; 
            Sum = 0.0;  
            count = 0;
        }

        public void Add(double number)
        {
            Sum += number;
            count++;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }
    }
}