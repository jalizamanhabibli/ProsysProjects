using System;

namespace Project2.Core.Dtos
{
    public class ExamTableDto
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public DateTime ExamDate { get; set; }
        public int Score { get; set; }
    }
}