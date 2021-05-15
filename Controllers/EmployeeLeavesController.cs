using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ezana.ShiftManagment.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;

namespace Ezana.ShiftManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLeavesController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public EmployeeLeavesController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeLeave>>> GetEmployeeLeavs()
        {
            return await _context.EmployeeLeaves.ToListAsync();
        }

        // GET: api/EmployeeSchedules/5
        [HttpGet("{id}", Name = "GetEmployeeLeave")]
        public async Task<ActionResult<EmployeeLeave>> GetEmployeeLeave(int id)
        {
            var employeeLeave = await _context.EmployeeLeaves.FindAsync(id); 

            if (employeeLeave == null)
            {
                return NotFound();
            }

            return employeeLeave;
        }

        // PUT: api/EmployeeSchedules/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<ActionResult<EmployeeLeave>> PutEmployeeLeave([FromBody] EmployeeLeave employeeLeave)
        {
            if (null == employeeLeave)
            {
                return BadRequest();
            }

            // _context.Entry(employeeSchedule).State = EntityState.Modified;
            _context.EmployeeLeaves.Update(employeeLeave);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeLeaveExists(employeeLeave.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            employeeLeave = await _context.EmployeeLeaves.FindAsync(employeeLeave.id);
            
            return Ok(employeeLeave);
        }

        // POST: api/EmployeeSchedules
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeLeave>> PostEmployeeLeave(EmployeeLeave employeeLeave)
        {
            _context.EmployeeLeaves.Add(employeeLeave);
            await _context.SaveChangesAsync();

            employeeLeave = await _context.EmployeeLeaves.FindAsync(employeeLeave.id);

            return CreatedAtAction("GetEmployeeSchedule", new { id = employeeLeave.id }, employeeLeave);
        }

        // DELETE: api/EmployeeSchedules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeLeave>> DeleteEmployeeLeave(int id)
        {
            var employeeLeave = await _context.EmployeeLeaves.FindAsync(id);
            if (employeeLeave == null)
            {
                return NotFound();
            }

            _context.EmployeeLeaves.Remove(employeeLeave);
            await _context.SaveChangesAsync();

            return employeeLeave;
        }

        private bool EmployeeLeaveExists(int id)
        {
            return _context.EmployeeSchedules.Any(e => e.EmployeeScheduleId == id);
        }
    }
}
