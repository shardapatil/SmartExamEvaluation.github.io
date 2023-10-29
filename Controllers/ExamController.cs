using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentLogin.Model;
using System.Data;

namespace StudentLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ExamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public IActionResult GetExams()
        {
            try
            {

                string connectionString = "server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;";

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Exam", cn);
                    SqlDataReader reader = cmdSelect.ExecuteReader();
                    var exams = new List<ExamTable>();

                    while (reader.Read())
                    {
                        var exam = new ExamTable
                        {
                            ExamId = reader.GetInt32(reader.GetOrdinal("ExamId")),
                            ExamTitle = reader.GetString(reader.GetOrdinal("ExamTitle")),
                            ExamDate = reader.GetDateTime(reader.GetOrdinal("ExamDate")),
                            TotalMarks = reader.GetInt32(reader.GetOrdinal("TotalMarks")),
                            PassingMarks = reader.GetInt32(reader.GetOrdinal("PassingMarks")),
                            ExamDurationMinutes = reader.GetTimeSpan(reader.GetOrdinal("ExamDurationMinutes"))

                        };

                        exams.Add(exam);
                    }

                    reader.Close();
                    cn.Close();
                    return Ok(exams);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult getSingleExam(int id)
        {
            try
            {

                string connectionString = "server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;";

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Exam where ExamId = @ExamId", cn);
                    cmdSelect.Parameters.AddWithValue("@ExamId", id);
                    SqlDataReader reader = cmdSelect.ExecuteReader();
                    var exams = new List<ExamTable>();

                    while (reader.Read())
                    {
                        var exam = new ExamTable
                        {
                            ExamId = reader.GetInt32(reader.GetOrdinal("ExamId")),
                            ExamTitle = reader.GetString(reader.GetOrdinal("ExamTitle")),
                            ExamDate = reader.GetDateTime(reader.GetOrdinal("ExamDate")),
                            TotalMarks = reader.GetInt32(reader.GetOrdinal("TotalMarks")),
                            PassingMarks = reader.GetInt32(reader.GetOrdinal("PassingMarks")),
                            ExamDurationMinutes = reader.GetTimeSpan(reader.GetOrdinal("ExamDurationMinutes"))

                        };

                        exams.Add(exam);
                    }

                    reader.Close();
                    cn.Close();
                    return Ok(exams);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}

    