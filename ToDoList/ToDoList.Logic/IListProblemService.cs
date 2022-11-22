using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Db.Entities;

namespace ToDoList.Logic
{
    public interface IListProblemService
    {
        Task<IEnumerable<Problem>> GetAll();

        List<Problem> GetArchive();

        Task Add(Problem problem);

        Task Update(Problem problem, int id);

        Task RemoveToArchive(int id);

        Task RemoveFromArchive(int id);
    }
}
