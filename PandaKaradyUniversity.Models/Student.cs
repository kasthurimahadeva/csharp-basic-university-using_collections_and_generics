using System;

namespace PandaKaradyUniversity.Models
{
    class Student : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Dob: {DateOfBirth}";
        }
    }
}