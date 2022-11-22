using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Db.Entities;

namespace ToDoList.WebDb
{
    public interface IListProblemRepository
    {
        Task<IEnumerable<Problem>> GetAll();

        Task<Problem> Get(int id);

        Task Add(Problem problem);

        Task Update(Problem problemToUpdate, Problem problem, int id);

        Task RemoveToArchive(Problem problemToRemove);

        Task RemoveFromArchive(Problem problemToAdd);
    }
}