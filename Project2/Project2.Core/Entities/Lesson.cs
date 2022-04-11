using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Project2.Core.Entities
{
    public class Lesson
    {
        public Lesson()
        {
            
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }

        public IEnumerable<Exam> Exams { get; set; }   


    }
}