using System;

namespace PandaKaradyUniversity.Models
{
    class Student : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        private const int StudentIdColNo = 0;
        private const int StudentNameColNo = 1;
        private const int StudentDobColNo = 2;

        public static Student StudentParse(string line)
        {
            var properties = line.Split(',');
            if(properties.Length != 3) throw new ArgumentException($"Invalid line : {line}");
                    
            var isIdParsed = int.TryParse(properties[StudentIdColNo], out var id);
            if(!isIdParsed) throw new ArgumentException($"Invalid Id -> line: {line}");

            var name = properties[StudentNameColNo];
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Invalid Name -> line : {line}");

            var isDobParsed = DateTime.TryParse(properties[StudentDobColNo], out var dob);
            if(!isDobParsed) throw new ArgumentException($"Invalid Dob -> line: {line}");

            var student = new Student {
                Id = id, 
                Name = name, 
                DateOfBirth = dob
            };
            return student;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Dob: {DateOfBirth.ToLongDateString()}";
        }
    }
}