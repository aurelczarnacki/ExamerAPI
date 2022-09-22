using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamerAPI.Data;
using ExamerAPI.Models;

namespace ExamerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : Controller
    {
        private readonly ExamerContext _context;

        public ExamsController(ExamerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Exam> GetExams()
        {
            return _context.Exams.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Exam> GetExam(int id)
        {
            var Exam = _context.Exams.Find(id);

            if (Exam == null)
            {
                return NotFound();
            }

            return Ok(new { Exam.Id, Exam.Title, Exam.Code, Exam.IsOn });
        }

        [HttpPost]
        public ActionResult<Exam> PostExam(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetExam), new { id = exam.Id }, exam) ;
        }



        [HttpPut("{id}")]
        public IActionResult PutExam(int id, Exam exam)
        {
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _context.Exams.Update(exam);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteExam(int id)
        {
            var Exam = _context.Exams.Find(id);

            if (Exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(Exam);
            _context.SaveChanges();

            return NoContent();
        }



        [HttpPost(template: "Enter")]
        public ActionResult<Exam> Enter(Exam exam)
        {

            var temp = _context.Exams
                .Where(x => x.Code == exam.Code)
                .FirstOrDefault();
            if (temp == null)
            {
                return BadRequest();
            }
            else
            {
                exam = temp;
                return Ok(new { exam.Id, exam.Title });
            }

        }



        private bool ExamExists(int id)
        {
            return (_context.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
