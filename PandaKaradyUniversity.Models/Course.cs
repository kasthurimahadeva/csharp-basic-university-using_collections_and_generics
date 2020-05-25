using System;
using System.Text;

namespace PandaKaradyUniversity.Models
{
    class Course : BaseEntity
    {
        public string Title { get; set; }
        
        private const int CourseIdColNo = 0;
        private const int CourseTitleColNo = 1;

        public static ParsingResult<Course> CourseParse(string line)
        {
            var errorBuilder = new StringBuilder();
            var result = new ParsingResult<Course>
            {
                Status = ParsingStatus.Failure
            };
            var properties = line.Split(',');
            // if(properties.Length != 2) throw new ArgumentException($"Invalid line : {line}");
            if (properties.Length != 2)
            {
                errorBuilder.Append("Invalid line");
            }
                    
            var isIdParsed = int.TryParse(properties[CourseIdColNo], out var id);
            // if(!isIdParsed) throw new ArgumentException($"Invalid Id -> line: {line}");
            if (!isIdParsed)
            {
                errorBuilder.Append("Invalid Id");
            }

            var title = properties[CourseTitleColNo];
            // if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException($"Invalid Name -> line : {line}");
            if (string.IsNullOrWhiteSpace(title))
            {
                errorBuilder.Append("Invalid title");
            }

            if (string.IsNullOrWhiteSpace(errorBuilder.ToString()))
            {
                result.Status = ParsingStatus.Success;
                result.Data = new Course
                {
                    Id = id,
                    Title = title
                };
            }
            else
            {
                errorBuilder.Append($". line -> {line}");
                result.ErrorReason = errorBuilder.ToString();
            }
            
            return result;
        }
                    
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}";
        }
    }
}