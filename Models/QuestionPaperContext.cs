using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class QuestionPaperContext : DbContext
    {
        public QuestionPaperContext(DbContextOptions<QuestionPaperContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }

        public DbSet<QuestionPaper> Questions { get; set; }

    }
}
