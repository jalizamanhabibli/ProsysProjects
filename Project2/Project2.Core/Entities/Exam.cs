using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Project2.Core.Entities
{
    public class Exam
    {
        private readonly ILazyLoader _lazyLoader;
        private Lesson _lesson;
        private Student _student;
        public Exam()
        {
        }
        public Exam(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public int Id { get; set; }
        public string LessonCode { get; set; }
        public int StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public int Score { get; set; }

        public Lesson Lesson
        {
            get => _lazyLoader.Load(this, ref _lesson);
            set =>  _lesson = value;
        }

        public Student Student
        {
            get => _lazyLoader.Load(this, ref _student);
            set => _student = value;
        }

    }
}