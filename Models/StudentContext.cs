using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            }
            optionsBuilder.UseSqlServer("server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }

        public DbSet<Student> Student { get; set; }


    }
}
