using System.Collections.Generic;
using System.Threading.Tasks;
using Project2.Core.Entities;
using Project2.Core.Services;
using Project2.Core.UniteOfWork;

namespace Project2.Service.Services
{
    public class LessonService:ILessonService
    {
        private readonly IUniteOfWork _uniteOfWork;

        public LessonService(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync()
        {
            return await _uniteOfWork.LessonRepository.GetAllAsync();
        }

        public async Task<Lesson> GetByIdAsync(object id)
        {
            return await _uniteOfWork.LessonRepository.GetByIdAsync(id);
        }

        public async Task<Lesson> AddAsync(Lesson entity)
        {
            await _uniteOfWork.LessonRepository.AddAsync(entity);
            await _uniteOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(Lesson entity)
        {
            _uniteOfWork.LessonRepository.Update(entity);
            await _uniteOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Lesson entity)
        {
            _uniteOfWork.LessonRepository.Remove(entity);
            await _uniteOfWork.CommitAsync();
        }
    }
}