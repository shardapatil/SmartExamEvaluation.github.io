using Backend.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuestionCreation.Models
{
    public class QuestionCreationDbContext : DbContext
    {
    
            public QuestionCreationDbContext(DbContextOptions<QuestionCreationDbContext> options) : base(options)
            {

            }
            public DbSet<QuestionCreationModel> CreateQues { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=SHARDA_PATIL;Initial Catalog=SmartExam;Integrated Security=True;Encrypt=true;TrustServerCertificate=true;");
            }


    }
}
