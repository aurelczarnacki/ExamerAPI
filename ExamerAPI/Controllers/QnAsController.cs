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
    public class QnAsController : Controller
    {
        private readonly ExamerContext _context;

        public QnAsController(ExamerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<QnA> GetQnAs()
        {
            return _context.QnAs.ToList();
        }

        [HttpGet(template: "questions/{eid}")]
        public async Task<ActionResult<IEnumerable<QnA>>> GetQuestions(int eid)
        {
            var ques = await(_context.QnAs
                .Select(x => new
                {
                    Id = x.Id,
                    QText = x.QText,
                    Options = new string[] {x.A1, x.A2, x.A3, x.A4},
                    ExamId = x.ExamId,
                    ACorrect = x.ACorrect
                }
                ).Where(x => x.ExamId == eid)
                .ToListAsync());
            return Ok(ques);
        }

        [HttpGet("{id}")]
        public ActionResult<QnA> GetQnA(int id)
        {
            var QnA = _context.QnAs.Find(id);

            if (QnA == null)
            {
                return NotFound();
            }

            return QnA;
        }

        [HttpPost]
        public ActionResult<QnA> PostQnA(QnA qnA)
        {
            _context.QnAs.Add(qnA);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetQnA), new { id = qnA.Id }, qnA);
        }

        [HttpPost(template:"check")]
        public async Task<ActionResult<QnA>> Check( int[] qnIds)
        {
            var answers = await (_context.QnAs
                .Where(x => qnIds.Contains(x.Id))
                .Select(y => new
                {
                    Id = y.Id,
                    QText = y.QText,
                    Options = new string[] { y.A1, y.A2, y.A3, y.A4 },
                    ACorrect = y.ACorrect,
                    ExamId = y.ExamId
                })).ToListAsync();
            return Ok(answers);
        }

        [HttpPut("{id}")]
        public IActionResult PutQnA(int id, QnA qnA)
        {
            if (id != qnA.Id)
            {
                return BadRequest();
            }

            _context.QnAs.Update(qnA);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteQnA(int id)
        {
            var QnA = _context.QnAs.Find(id);

            if (QnA == null)
            {
                return NotFound();
            }

            _context.QnAs.Remove(QnA);
            _context.SaveChanges();

            return NoContent();
        }



        private bool ExamExists(int id)
        {
            return (_context.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
