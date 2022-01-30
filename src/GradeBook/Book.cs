using System;
using System.Collections.Generic;


namespace GradeBook
{
    //delegate for event(needed to subscribe to event in main app)
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public String Name{get;set;}
    }

    public abstract class Book : NamedObject, IBookInterface
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;
        
        //event field
        public override event GradeAddedDelegate GradeAdded;
        
        public InMemoryBook(string name): base(name)
        {
            grades = new List<double>();
            this.Name = name;

        }
        public override void AddGrade(double grade)
        {
            if(grade >=0 && grade <= 100)
            {
                this.grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException("Invalid grade!");
            }

        }

        

        public double getTotalGrade()
        {
            double sum = 0.0;

            foreach(double x in grades)
            {
                sum += x;
            }

            return sum;
        }

        public double getAverageGrade()
        {
            double sum = getTotalGrade();
            double average = sum/grades.Count;
            return average;
        }

        public double getHighestGrade()
        {
            double highGrade = double.MinValue;
            
            foreach(double num in grades)
            {
                highGrade = Math.Max(num, highGrade);
            }

            return highGrade;
        }

        public double getLowestGrade()
        {
            double lowGrade = double.MaxValue;
            
                foreach(double num in grades)
            {
                lowGrade = Math.Min(num, lowGrade);
            }

            return lowGrade;
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach(double grade in grades)
            {
                result.Add(grade);
            }

            
            
            
            return result;
    
        }

        

    }
}