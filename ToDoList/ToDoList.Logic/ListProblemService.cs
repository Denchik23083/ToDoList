using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Db.Entities;
using ToDoList.WebDb;

namespace ToDoList.Logic
{
    public class ListProblemService : IListProblemService
    {
        private readonly IListProblemRepository _repository;
        public static List<Problem> ArchiveProblem = new();

        public ListProblemService(IListProblemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Problem>> GetAll()
        {
            return await _repository.GetAll();
        }

        public List<Problem> GetArchive()
        {
            return ArchiveProblem;
        }

        public async Task Add(Problem problem)
        {
            await _repository.Add(problem);
        }

        public async Task Update(Problem problem, int id)
        {
            var problemToUpdate = await _repository.Get(id);

            if (problemToUpdate is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.Update(problemToUpdate, problem, id);
        }

        public async Task RemoveToArchive(int id)
        {
            var problemToRemove = await _repository.Get(id);

            if (problemToRemove is null)
            {
                throw new ArgumentNullException();
            }

            ArchiveProblem.Add(problemToRemove);

            await _repository.RemoveToArchive(problemToRemove);
        }

        public async Task RemoveFromArchive(int id)
        {
            var problemToRemove = ArchiveProblem.FirstOrDefault(b => b.Id == id);

            if (problemToRemove is null)
            {
                throw new ArgumentNullException();
            }

            ArchiveProblem.Remove(problemToRemove);

            problemToRemove.Id = 0;

            await _repository.RemoveFromArchive(problemToRemove);
        }
    }
}
