using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Db;
using ToDoList.Db.Entities;

namespace ToDoList.WebDb
{
    public class ListProblemRepository : IListProblemRepository
    {
        private readonly ListProblemContext _context;

        public ListProblemRepository(ListProblemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Problem>> GetAll()
        {
            return await _context.Problems.ToListAsync();
        }

        public Task<Problem> Get(int id)
        {
            return _context.Problems.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Add(Problem problem)
        {
            await _context.Problems.AddAsync(problem);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Problem problemToUpdate, Problem problem, int id)
        {
            problemToUpdate.IsCompleted = problem.IsCompleted;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveToArchive(Problem problemToRemove)
        {
            _context.Problems.Remove(problemToRemove);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromArchive(Problem problemToAdd)
        {
            await _context.Problems.AddAsync(problemToAdd);
            await _context.SaveChangesAsync();
        }
    }
}
