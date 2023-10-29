using Backend.BAL;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {

        private readonly StudentContext _context;

        public StudentRegistrationController(StudentContext context)
        {
            _context = context;
        }

        [HttpPost("studentReg")]
        public async Task<IActionResult> RegisterStudent(Student studreq)
        {
            StudentRegistrationBAL ObjStudBAL = new StudentRegistrationBAL();
            int ObjResponse;

            if (await _context.Student.AnyAsync(s => s.StudentEmail == studreq.StudentEmail))
            {
                return Conflict("Email already registered");
            }
            else if (await _context.Student.AnyAsync(s => s.StudentUsername == studreq.StudentUsername))
            {
                return Conflict("username already exists");
            }
            else
            {
                ObjResponse = ObjStudBAL.RegisterStudent(studreq);

                if (ObjResponse > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

    }
}
