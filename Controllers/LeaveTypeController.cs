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
    public class LeaveTypeController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public LeaveTypeController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Lookups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveType>>> GetLookups()
        {
            return await _context.LeaveTypes.ToListAsync();
        }

        // GET: api/Lookups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveType>> GetLookup(int id)
        {
            var lookup = await _context.LeaveTypes.FindAsync(id);

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
        public async Task<IActionResult> PutLookup(int id, LeaveType lookup)
        {
            if (id != lookup.Id)
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
        public async Task<ActionResult<LeaveType>> PostLookup(LeaveType lookup)
        {
            _context.LeaveTypes.Add(lookup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLookup", new { id = lookup.Id }, lookup);
        }

        // DELETE: api/Lookups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveType>> DeleteLookup(int id)
        {
            var lookup = await _context.LeaveTypes.FindAsync(id);
            if (lookup == null)
            {
                return NotFound();
            }

            _context.LeaveTypes.Remove(lookup);
            await _context.SaveChangesAsync();

            return lookup;
        }

        private bool LookupExists(int id)
        {
            return _context.Lookups.Any(e => e.LookupId == id);
        }
    }
}
