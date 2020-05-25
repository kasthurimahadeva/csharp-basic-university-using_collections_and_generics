using System;
using System.IO;
using PandaKaradyUniversity.Models;

namespace PandaKaradyUniversity
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            using (var reader = File.OpenText(Path.Combine("resources", "students.csv")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(Student.StudentParse(line));
                    line = reader.ReadLine();
                }
            }
            
            using (var reader = File.OpenText(Path.Combine("resources", "courses.csv")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(Course.CourseParse(line));
                    line = reader.ReadLine();
                }
            }
        }
    }
}