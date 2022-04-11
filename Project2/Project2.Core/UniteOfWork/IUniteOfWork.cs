using System.Threading.Tasks;
using Project2.Core.Entities;
using Project2.Core.Repositories;

namespace Project2.Core.UniteOfWork
{
    public interface IUniteOfWork
    {
        public IGenericRepository<Lesson> LessonRepository { get; }
        public IGenericRepository<Student> StudentRepository { get; }
        public IGenericRepository<Exam> ExamRepository { get; }
        Task CommitAsync();
        void Commit();
    }
}