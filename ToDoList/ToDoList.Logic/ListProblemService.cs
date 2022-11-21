using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Db.Entities;
using ToDoList.WebDb;

namespace ToDoList.Logic
{
    public class ListProblemService : IListProblemService
    {
        private readonly IListProblemRepository _repository;

        public ListProblemService(IListProblemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Problem>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
