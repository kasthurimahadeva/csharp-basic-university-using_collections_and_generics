using System;

namespace PandaKaradyUniversity.Models
{
    class Course : BaseEntity
    {
        public string Title { get; set; }
        
        private const int CourseIdColNo = 0;
        private const int CourseTitleColNo = 1;

        public static Course CourseParse(string line)
        {
            var properties = line.Split(',');
            if(properties.Length != 2) throw new ArgumentException($"Invalid line : {line}");
                    
            var isIdParsed = int.TryParse(properties[CourseIdColNo], out var id);
            if(!isIdParsed) throw new ArgumentException($"Invalid Id -> line: {line}");

            var title = properties[CourseTitleColNo];
            if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException($"Invalid Name -> line : {line}");

            var course = new Course {
                Id = id, 
                Title = title
            };

            return course;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}";
        }
    }
}