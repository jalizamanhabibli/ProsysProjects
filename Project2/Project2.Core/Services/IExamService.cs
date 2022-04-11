using System.Collections.Generic;
using System.Threading.Tasks;
using Project2.Core.Entities;

namespace Project2.Core.Services
{
    public interface IExamService:IService<Exam>
    {
        Task<(Exam exam, IEnumerable<Student> students, IEnumerable<Lesson> lessons)> GetExamWithStudentsAndLessons(int id);
    }
}