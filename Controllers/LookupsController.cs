using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ezana.ShiftManagment.API.Models;

namespace Ezana.ShiftManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public LookupsController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Lookups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lookup>>> GetLookups()
        {
            return await _context.Lookups.ToListAsync();
        }

        // GET: api/Lookups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lookup>> GetLookup(int id)
        {
            var lookup = await _context.Lookups.FindAsync(id);

            if (lookup == null)
            {
                return NotFound();
            }

            return lookup;
        }

        // PUT: api/Lookups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLookup(int id, Lookup lookup)
        {
            if (id != lookup.LookupId)
            {
                return BadRequest();
            }

            _context.Entry(lookup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LookupExists(id))
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

        // POST: api/Lookups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Lookup>> PostLookup(Lookup lookup)
        {
            _context.Lookups.Add(lookup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLookup", new { id = lookup.LookupId }, lookup);
        }

        // DELETE: api/Lookups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lookup>> DeleteLookup(int id)
        {
            var lookup = await _context.Lookups.FindAsync(id);
            if (lookup == null)
            {
                return NotFound();
            }

            _context.Lookups.Remove(lookup);
            await _context.SaveChangesAsync();

            return lookup;
        }

        private bool LookupExists(int id)
        {
            return _context.Lookups.Any(e => e.LookupId == id);
        }
    }
}
