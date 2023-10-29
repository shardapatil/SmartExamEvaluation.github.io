using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuestionCreation.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class QuestionCreationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public QuestionCreationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<QuestionCreationModel>> AddQuestion(QuestionCreationModel question)
        {

            //SqlConnection cn = new SqlConnection( _configuration.GetConnectionString("QuestionCreationDbContext").ToString());
            //string ConnectionString = cn.ConnectionString;
            //SqlConnection ObjConnection = new SqlConnection(ConnectionString);
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SmartExamContext")))
                {
                    await connection.OpenAsync();

                    string query = @"INSERT INTO Question (Questext, Option1, Option2, Option3, Option4, Answer)
                             VALUES (@Questext, @Option1, @Option2, @Option3, @Option4, @Answer)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Questext", question.Questext);
                        command.Parameters.AddWithValue("@Option1", question.Option1);
                        command.Parameters.AddWithValue("@Option2", question.Option2);
                        command.Parameters.AddWithValue("@Option3", question.Option3);
                        command.Parameters.AddWithValue("@Option4", question.Option4);
                        command.Parameters.AddWithValue("@Answer", question.Answer);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            // Successfully inserted the data
                            return Ok();
                        }
                        else
                        {
                            // Insertion failed
                            return NotFound();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
