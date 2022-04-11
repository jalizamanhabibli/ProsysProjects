using System.Collections.Generic;

namespace Project2.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }

        public IEnumerable<Exam> Exams { get; set; }
    }
}