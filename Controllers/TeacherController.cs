using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class TeacherController : ControllerBase
    {

        private readonly TeacherDbContext _teacherDbContext;

        public TeacherController(TeacherDbContext teacherDbContext)
        {
            _teacherDbContext = teacherDbContext;
        }

        [HttpGet]
        [Route("GetTeacher")]
        public async Task<IEnumerable<Teacher>> GetTeacher()
        {
            return await _teacherDbContext.Teacher.ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(Teacher tr)
        {
            if (ModelState.IsValid)
            {
                _teacherDbContext.Teacher.Add(tr);
                await _teacherDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }


    }
}
