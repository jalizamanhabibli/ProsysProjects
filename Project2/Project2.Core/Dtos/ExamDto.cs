using System;

namespace Project2.Core.Dtos
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string LessonCode { get; set; }
        public LessonDto Lesson { get; set; }
        public int StudentId { get; set; }
        public StudentDto Student { get; set; }
        public DateTime? ExamDate { get; set; }
        public int Score { get; set; }


    }
}