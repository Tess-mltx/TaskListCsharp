using Microsoft.EntityFrameworkCore;
using TaskList.Models.Entities;

namespace TaskList.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }

        public DbSet<Assignment> Tasks { get; set; }
    }
}
