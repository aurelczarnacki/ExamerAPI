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
    public class ScoresController : Controller
    {
        private readonly ExamerContext _context;

        public ScoresController(ExamerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Score> GetScores()
        {
            return _context.Scores.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Score> GetScore(int id)
        {
            var Score = _context.Scores.Find(id);

            if (Score == null)
            {
                return NotFound();
            }

            return Score;
        }

        [HttpPost]
        public ActionResult<Score> PostScore(Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetScore), new { id = score.Id }, score);
        }



        [HttpPut("{id}")]
        public IActionResult PutScore(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            _context.Scores.Update(score);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteScore(int id)
        {
            var Score = _context.Scores.Find(id);

            if (Score == null)
            {
                return NotFound();
            }

            _context.Scores.Remove(Score);
            _context.SaveChanges();

            return NoContent();
        }






        private bool ScoreExists(int id)
        {
            return (_context.Scores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
