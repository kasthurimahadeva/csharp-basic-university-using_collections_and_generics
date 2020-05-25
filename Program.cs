using System;
using System.IO;
using PandaKaradyUniversity.Models;

namespace PandaKaradyUniversity
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            var studentFileReader = new FileReader<Student>(new StudentParser());
            studentFileReader.Process("students.csv"); 
            
            var courseFileReader = new FileReader<Course>(new CourseParser());
            courseFileReader.Process("courses.csv");
        }
    }
}