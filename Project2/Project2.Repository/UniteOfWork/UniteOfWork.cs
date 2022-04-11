using System;
using System.Threading.Tasks;
using Project2.Core.Entities;
using Project2.Core.Repositories;
using Project2.Core.UniteOfWork;
using Project2.Repository.Repositories;

namespace Project2.Repository.UniteOfWork
{
    public class UniteOfWork:IUniteOfWork,IDisposable
    {
        private readonly AppDbContext _dbContext;
        public IGenericRepository<Lesson> LessonRepository => new GenericRepository<Lesson>(_dbContext);
        public IGenericRepository<Student> StudentRepository => new GenericRepository<Student>(_dbContext);
        public IGenericRepository<Exam> ExamRepository => new GenericRepository<Exam>(_dbContext);

        public UniteOfWork(AppDbContext dbContext, IGenericRepository<Lesson> lessonRepository)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}