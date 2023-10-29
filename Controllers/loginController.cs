using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentLogin.Model;
using System.Data;

namespace StudentLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public loginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<ActionResult<Login>> loginCheck(Login login)
        {

            //BAL call Logincheck()
            string storedProcedureName = "";

            switch (login.role_ID)
            {
                case 1:
                    storedProcedureName = "login2";
                    break;
                case 2:
                    storedProcedureName = "Teacherlogin";
                    break;
                case 3:
                    storedProcedureName = "Studentlogin";
                    break;
                default:
                    return BadRequest("Invalid role ID");
            }

            string connectionString = "server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand(storedProcedureName,cn);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@username", login.userName);
                cmdInsert.Parameters.AddWithValue("@pw", login.password);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    cn.Close();
                    //int userId = dr.GetInt32(dr.GetOrdinal("AdminId")); // Assuming the column name is "UserId"
                    //dr.Close();
                    //cn.Close();

                    //// Store the user's ID in a session variable
                    //HttpContext.Session.SetInt32("UserId", userId);
                    return Ok();

                }
                else
                {
                    dr.Close();
                    cn.Close();
                    return NotFound();
                }
            }
            

        }

    }
}

