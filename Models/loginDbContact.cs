using Microsoft.EntityFrameworkCore;


namespace StudentLogin.Model
{
    public class loginDbContact : DbContext
    {
        
        
            public loginDbContact(DbContextOptions<loginDbContact> options) : base(options)
            {

            }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }

        //public DbSet<Login> Students { get; set; }

        public DbSet<Login> Logins { get; set; }
        }

        
        
    }

