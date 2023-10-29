
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo.Wmi;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<StudentContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("StudentContext")));

                builder.Services.AddDbContext<QuestionPaperContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("QuestionPaperContext")));

            builder.Services.AddDbContext<TeacherDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("TeacherContext")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}