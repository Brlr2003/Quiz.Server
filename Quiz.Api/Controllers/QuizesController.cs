using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Api.Models;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizesController : ControllerBase
    {
        private readonly QuizContext _context;

        public QuizesController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/Quizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quizz>>> GetQuizes()
        {
          if (_context.Quizes == null)
          {
              return NotFound();
          }
            return await _context.Quizes.ToListAsync();
        }

        // GET: api/Quizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quizz>> GetQuizz(long id)
        {
          if (_context.Quizes == null)
          {
              return NotFound();
          }
            var quizz = await _context.Quizes.FindAsync(id);

            if (quizz == null)
            {
                return NotFound();
            }

            return quizz;
        }

        // PUT: api/Quizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizz(long id, Quizz quizz)
        {
            if (id != quizz.Id)
            {
                return BadRequest();
            }

            _context.Entry(quizz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizzExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Quizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quizz>> PostQuizz(Quizz quizz)
        {
          if (_context.Quizes == null)
          {
              return Problem("Entity set 'QuizContext.Quizes'  is null.");
          }
            _context.Quizes.Add(quizz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizz", new { id = quizz.Id }, quizz);
        }

        // DELETE: api/Quizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizz(long id)
        {
            if (_context.Quizes == null)
            {
                return NotFound();
            }
            var quizz = await _context.Quizes.FindAsync(id);
            if (quizz == null)
            {
                return NotFound();
            }

            _context.Quizes.Remove(quizz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizzExists(long id)
        {
            return (_context.Quizes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
