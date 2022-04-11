using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T> >GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

    }
}