using System.Collections.Generic;
using System.Threading.Tasks;
using Project2.Core.Entities;
using Project2.Core.Services;
using Project2.Core.UniteOfWork;

namespace Project2.Service.Services
{
    public class StudentService:IStudentService
    {
        private readonly IUniteOfWork _uniteOfWork;

        public StudentService(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _uniteOfWork.StudentRepository.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(object id)
        {
            return await _uniteOfWork.StudentRepository.GetByIdAsync(id);
        }

        public async Task<Student> AddAsync(Student entity)
        {
            await _uniteOfWork.StudentRepository.AddAsync(entity);
            await _uniteOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(Student entity)
        {
            _uniteOfWork.StudentRepository.Update(entity);
            await _uniteOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Student entity)
        {
            _uniteOfWork.StudentRepository.Remove(entity);
            await _uniteOfWork.CommitAsync();
        }
    }
}