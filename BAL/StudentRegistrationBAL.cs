using Backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Backend.BAL
{
    public class StudentRegistrationBAL
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public StudentRegistrationBAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StudentContext");
        }

        public StudentRegistrationBAL()
        {

        }

        private SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("StudentContext").ToString());
            string ConnectionString = cn.ConnectionString;
            return new SqlConnection(ConnectionString);
        }

        #region Method to Add Student
        public int RegisterStudent(Student studreq)
        {
            string connectionString = "server=SHARDA_PATIL;database=SmartExam;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Student objres = new Student();
                using (SqlCommand cmd = new SqlCommand("USP_Insert_Student", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentFName", studreq.StudentFName);
                    cmd.Parameters.AddWithValue("@StudentMName", studreq.StudentMName);
                    cmd.Parameters.AddWithValue("@StudentLName", studreq.StudentLName);
                    cmd.Parameters.AddWithValue("@StudentGenderId", studreq.GenderID);
                    cmd.Parameters.AddWithValue("@StudentEmail", studreq.StudentEmail);
                    cmd.Parameters.AddWithValue("@StudentContact", studreq.StudentContact);
                    cmd.Parameters.AddWithValue("@StudentAddress", studreq.StudentAddress);
                    cmd.Parameters.AddWithValue("@StudentUsername", studreq.StudentUsername);
                    cmd.Parameters.AddWithValue("@StudentPassword", studreq.StudentPassword);

                    int cnt =cmd.ExecuteNonQuery();

                    if (cnt > 0)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }
        #endregion



    }

}
