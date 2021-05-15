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
    public class LookupTypesController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public LookupTypesController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/LookupTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LookupType>>> GetlookupTypes()
        {
            return await _context.lookupTypes.ToListAsync();
        }

        // GET: api/LookupTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LookupType>> GetLookupType(int id)
        {
            var lookupType = await _context.lookupTypes.FindAsync(id);

            if (lookupType == null)
            {
                return NotFound();
            }

            return lookupType;
        }

        // PUT: api/LookupTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLookupType(int id, LookupType lookupType)
        {
            if (id != lookupType.LookUpTypeId)
            {
                return BadRequest();
            }

            _context.Entry(lookupType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LookupTypeExists(id))
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

        // POST: api/LookupTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LookupType>> PostLookupType(LookupType lookupType)
        {
            _context.lookupTypes.Add(lookupType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLookupType", new { id = lookupType.LookUpTypeId }, lookupType);
        }

        // DELETE: api/LookupTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LookupType>> DeleteLookupType(int id)
        {
            var lookupType = await _context.lookupTypes.FindAsync(id);
            if (lookupType == null)
            {
                return NotFound();
            }

            _context.lookupTypes.Remove(lookupType);
            await _context.SaveChangesAsync();

            return lookupType;
        }

        private bool LookupTypeExists(int id)
        {
            return _context.lookupTypes.Any(e => e.LookUpTypeId == id);
        }
    }
}
