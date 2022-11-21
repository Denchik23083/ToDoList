using Microsoft.EntityFrameworkCore;
using ToDoList.Db.Entities;

namespace ToDoList.Db
{
    public class ListProblemContext : DbContext
    {
        public ListProblemContext(DbContextOptions options) : base(options) { }

        public DbSet<Problem> Problems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
