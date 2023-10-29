using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionPaperController : ControllerBase
    {

        private readonly QuestionPaperContext _questionContext;
        public QuestionPaperController(QuestionPaperContext questionContext)
        {
            _questionContext = questionContext;
        }

        // GET: api/<QuestionPaperController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionPaper>>> getAllQuestions()
        {
            if (_questionContext.Questions == null)
            {
                return NotFound();
            }
            return await _questionContext.Questions.ToListAsync();
        }

    }
}
