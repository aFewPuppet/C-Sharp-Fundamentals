using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            StreamWriter sw = File.AppendText(this.Name + ".txt");
            sw.WriteLine(grade);
            sw.Close();

            Console.WriteLine("Grade written to file");
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();

            using(StreamReader sr = File.OpenText(this.Name + ".txt"))
            {
                string value = "";
                while((value = sr.ReadLine()) != null)
                {
                    double gradeFromFile = Convert.ToDouble(value);
                    stats.Add(gradeFromFile);
                }     
            }
            return stats;
        }
    }
}