using Microsoft.EntityFrameworkCore;

namespace StudentLogin.Model
{
    public class ExamDbContact : DbContext
    {
        public ExamDbContact(DbContextOptions<ExamDbContact> options) : base(options)
        {

        }

        //public DbSet<Login> Students { get; set; }

        public DbSet<ExamTable> Exams { get; set; }
    }
}
