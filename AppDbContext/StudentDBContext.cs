using Microsoft.EntityFrameworkCore;
using ASPCoreWebAPICRUD.Models;

namespace ASPCoreWebAPICRUD.AppDbContext
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base(options)
        {
            
        }

        public DbSet<Students> Student { get; set; }

    }
    
}
