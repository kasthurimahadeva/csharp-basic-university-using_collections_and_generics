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
            var propertities = line.Split(',');
            if(propertities.Length != 2) throw new ArgumentException($"Invalid line : {line}");
                    
            var isIdParsed = int.TryParse(propertities[CourseIdColNo], out var id);
            if(!isIdParsed) throw new ArgumentException($"Invalid Id -> line: {line}");

            var title = propertities[CourseTitleColNo];
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