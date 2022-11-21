using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Db.Entities;

namespace ToDoList.WebDb
{
    public interface IListProblemRepository
    {
        Task<IEnumerable<Problem>> GetAll();
    }
}