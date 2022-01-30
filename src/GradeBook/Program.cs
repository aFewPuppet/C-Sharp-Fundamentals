using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBookInterface book1 = new DiskBook("Adel's Book");

            //subscribing to the grade added event(pointing delegate to OnGradeAdded)
            book1.GradeAdded += OnGradeAdded;


        /*  book1.addGrade(25.3);
            book1.addGrade(32.6);
            book1.addGrade(45.2);
            book1.addGrade(56.7);*/

            AddGrade(book1);

            Statistics stats = book1.GetStatistics();

            Console.WriteLine("for the book named " + book1.Name + "Average grade = " + stats.Average + " Highest grade = " + stats.High + " Lowest grade = " + stats.Low + "Letter Grade = " + stats.letterGrade);
            
            
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }


        public static void AddGrade(IBookInterface book)
        {
            var done = false;

            while(!done)
            {
                Console.WriteLine("Enter a grade or press q to quit: ");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    done = true;
                    break;
                }
                try
                {
                    if(Convert.ToDouble(input) >=0 && Convert.ToDouble(input) <= 100)
                    {
                        book.AddGrade(Convert.ToDouble(input));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid grade!");
                    }  
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }   
            }    
        }
    }
}
