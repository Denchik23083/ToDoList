using System;
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
    }
}
