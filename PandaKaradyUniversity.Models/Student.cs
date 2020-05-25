using System;
using System.Text;
using PandaKaradyUniversity.Models;

namespace PandaKaradyUniversity.Models
{
    class Student : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        private const int StudentIdColNo = 0;
        private const int StudentNameColNo = 1;
        private const int StudentDobColNo = 2;

        public static ParsingResult<Student> StudentParse(string line)
        {
            var result = new ParsingResult<Student>
            {
                Status = ParsingStatus.Failure
            };
            var errorReasonBuilder = new StringBuilder();
            var properties = line.Split(',');
            // if(properties.Length != 3) throw new ArgumentException($"Invalid line : {line}");
            if (properties.Length != 3)
            {
                errorReasonBuilder.Append("Invalid line");
            }
                    
            var isIdParsed = int.TryParse(properties[StudentIdColNo], out var id);
            // if(!isIdParsed) throw new ArgumentException($"Invalid Id -> line: {line}");
            if (!isIdParsed)
            {
                errorReasonBuilder.Append("Invalid Id");
            }

            var name = properties[StudentNameColNo];
            // if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Invalid Name -> line : {line}");
            if (string.IsNullOrWhiteSpace(name))
            {
                errorReasonBuilder.Append("Invalid name");
            }

            var isDobParsed = DateTime.TryParse(properties[StudentDobColNo], out var dob);
            // if(!isDobParsed) throw new ArgumentException($"Invalid Dob -> line: {line}");
            if (!isDobParsed)
            {
                errorReasonBuilder.Append("Invalid Dob");
            }

            if (string.IsNullOrWhiteSpace(errorReasonBuilder.ToString()))
            {
                result.Status = ParsingStatus.Success;
                result.Data = new Student {
                    Id = id, 
                    Name = name, 
                    DateOfBirth = dob
                };
            }
            else
            {
                errorReasonBuilder.Append($". line -> {line}");
                result.ErrorReason = errorReasonBuilder.ToString();
            }
            return result;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Dob: {DateOfBirth.ToLongDateString()}";
        }
    }
}