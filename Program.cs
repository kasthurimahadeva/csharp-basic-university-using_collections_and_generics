using System;
using System.IO;
using PandaKaradyUniversity.Models;

namespace PandaKaradyUniversity
{
    class Program
    {
        private const int StudentIdColNo = 0;
        private const int StudentNameColNo = 1;
        private const int StudentDobColNo = 2;

        private const int CourseIdColNo = 0;
        private const int CourseTitleColNo = 1;
        
        static void Main(string[] args)
        {
            using (var reader = File.OpenText(Path.Combine("resources", "students.csv")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    var propertities = line.Split(',');
                    if(propertities.Length != 3) throw new ArgumentException($"Invalid line : {line}");
                    
                    var isIdParsed = int.TryParse(propertities[StudentIdColNo], out var id);
                    if(!isIdParsed) throw new ArgumentException($"Invalid Id -> line: {line}");

                    var name = propertities[StudentNameColNo];
                    if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Invalid Name -> line : {line}");

                    var isDobParsed = DateTime.TryParse(propertities[StudentDobColNo], out var dob);
                    if(!isDobParsed) throw new ArgumentException($"Invalid Dob -> line: {line}");

                    var student = new Student {
                        Id = id, 
                        Name = name, 
                        DateOfBirth = dob
                    };

                    line = reader.ReadLine();
                }
            }
            
            using (var reader = File.OpenText(Path.Combine("resources", "courses.csv")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    var propertities = line.Split(',');
                    if(propertities.Length != 2) throw new ArgumentException($"Invalid line : {line}");
                    
                    var isIdParsed = int.TryParse(propertities[CourseIdColNo], out var id);
                    if(!isIdParsed) throw new ArgumentException($"Invalid Id -> line: {line}");

                    var title = propertities[CourseTitleColNo];
                    if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException($"Invalid Name -> line : {line}");

                    var student = new Course {
                        Id = id, 
                        Title = title
                    };

                    line = reader.ReadLine();
                }
            }
        }
    }
}