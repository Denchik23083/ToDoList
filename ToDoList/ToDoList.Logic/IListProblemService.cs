using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Db.Entities;

namespace ToDoList.Logic
{
    public interface IListProblemService
    {
        Task<IEnumerable<Problem>> GetAll();
    }
}
