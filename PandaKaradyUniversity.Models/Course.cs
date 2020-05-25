using System;
using System.Text;

namespace PandaKaradyUniversity.Models
{
    class Course : BaseEntity
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}";
        }
    }
}