using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularProjectAPI.Data;
using AngularProjectAPI.Models;

namespace AngularProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactiesController : ControllerBase
    {
        private readonly NewsContext _context;

        public ReactiesController(NewsContext context)
        {
            _context = context;
        }

        // GET: api/Reacties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reactie>>> GetReacties()
        {
            return await _context.Reacties.ToListAsync();
        }

        // GET: api/Reacties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reactie>> GetReactie(int id)
        {
            var reactie = await _context.Reacties.FindAsync(id);

            if (reactie == null)
            {
                return NotFound();
            }

            return reactie;
        }

        // PUT: api/Reacties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReactie(int id, Reactie reactie)
        {
            if (id != reactie.ReactieID)
            {
                return BadRequest();
            }

            _context.Entry(reactie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactieExists(id))
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

        // POST: api/Reacties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reactie>> PostReactie(Reactie reactie)
        {
            _context.Reacties.Add(reactie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReactie", new { id = reactie.ReactieID }, reactie);
        }

        // DELETE: api/Reacties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reactie>> DeleteReactie(int id)
        {
            var reactie = await _context.Reacties.FindAsync(id);
            if (reactie == null)
            {
                return NotFound();
            }

            _context.Reacties.Remove(reactie);
            await _context.SaveChangesAsync();

            return reactie;
        }

        private bool ReactieExists(int id)
        {
            return _context.Reacties.Any(e => e.ReactieID == id);
        }
    }
}
