using System.Collections.Generic;
using System.Threading.Tasks;
using Project2.Core.Entities;
using Project2.Core.Services;
using Project2.Core.UniteOfWork;

namespace Project2.Service.Services
{
    public class ExamService:IExamService
    {
        private readonly IUniteOfWork _uniteOfWork;

        public ExamService(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _uniteOfWork.ExamRepository.GetAllAsync();
        }

        public async Task<Exam> GetByIdAsync(object id)
        {
            return await _uniteOfWork.ExamRepository.GetByIdAsync(id);
        }

        public async Task<Exam> AddAsync(Exam entity)
        {
            entity.Lesson = await _uniteOfWork.LessonRepository.GetByIdAsync(entity.LessonCode);
            entity.Student = await _uniteOfWork.StudentRepository.GetByIdAsync(entity.StudentId);
            await _uniteOfWork.ExamRepository.AddAsync(entity);
            await _uniteOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(Exam entity)
        {
            entity.Lesson = await _uniteOfWork.LessonRepository.GetByIdAsync(entity.LessonCode);
            entity.Student = await _uniteOfWork.StudentRepository.GetByIdAsync(entity.StudentId);
            _uniteOfWork.ExamRepository.Update(entity);
            await _uniteOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Exam entity)
        {
            _uniteOfWork.ExamRepository.Remove(entity);
            await _uniteOfWork.CommitAsync();
        }

        public async Task<(Exam exam, IEnumerable<Student> students, IEnumerable<Lesson> lessons)> GetExamWithStudentsAndLessons(int id)
        {
            var exam =await _uniteOfWork.ExamRepository.GetByIdAsync(id);
            var students = await _uniteOfWork.StudentRepository.GetAllAsync();
            var lessons = await _uniteOfWork.LessonRepository.GetAllAsync();
            return (exam, students, lessons);
        }
    }
}