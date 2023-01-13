using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LimitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Limits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Limit>>> GetLimit()
        {
            return await _context.Limit.ToListAsync();
        }

        // GET: api/Limits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Limit>> GetLimit(int id)
        {
            try
            {
                if (!(id > 0))
                {
                    return null;
                }
                var limit = await _context.Limit.FindAsync(id);

            if (limit == null)
            {
                return NotFound();
            }

            return limit;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Limits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLimit(int id, Limit limit)
        {
            if (id != limit.Id)
            {
                return BadRequest();
            }

            _context.Entry(limit).State = EntityState.Modified;

            try
            {
                if (!(id > 0))
                {
                    return null;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LimitExists(id))
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

        // POST: api/Limits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Limit>> PostLimit(Limit limit)
        {
            if (String.IsNullOrWhiteSpace(limit.Value))
            {
                return null;
            }
            try
            {
            _context.Limit.Add(limit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLimit", new { id = limit.Id }, limit);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Limits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLimit(int id)
        {
            try
            {
                if (!(id > 0))
                {
                    return null;
                }
                var limit = await _context.Limit.FindAsync(id);
            if (limit == null)
            {
                return NotFound();
            }

            _context.Limit.Remove(limit);
            await _context.SaveChangesAsync();

            return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool LimitExists(int id)
        {
            return _context.Limit.Any(e => e.Id == id);
        }
    }
}
