using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    using Microsoft.EntityFrameworkCore;
    public class TeacherDbContext : DbContext
        {
            public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
            {

            }
            public DbSet<Teacher> Teacher { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            }
        }
    
}