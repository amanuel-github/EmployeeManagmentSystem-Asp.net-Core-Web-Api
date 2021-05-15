using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ezana.ShiftManagment.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ezana.ShiftManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSchedulesController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public EmployeeSchedulesController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSchedule>>> GetSchedules()
        {
            return await _context.EmployeeSchedules.Include(E => E.Shift).ToListAsync();
        }

        // GET: api/EmployeeSchedules/5
        [HttpGet("{id}", Name = "GetEmployeeSchedule")]
        public async Task<ActionResult<EmployeeSchedule>> GetEmployeeSchedule(int id)
        {
            var employeeSchedule = await _context.EmployeeSchedules.Include(E => E.Shift).SingleOrDefaultAsync(x => x.EmployeeScheduleId == id);

            if (employeeSchedule == null)
            {
                return NotFound();
            }

            return employeeSchedule;
        }

        // PUT: api/EmployeeSchedules/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<ActionResult<EmployeeSchedule>> PutEmployeeSchedule([FromBody] EmployeeSchedule employeeSchedule)
        {
            if (null == employeeSchedule)
            {
                return BadRequest();
            }

            // _context.Entry(employeeSchedule).State = EntityState.Modified;
            _context.EmployeeSchedules.Update(employeeSchedule);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeScheduleExists(employeeSchedule.EmployeeScheduleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            employeeSchedule = await _context.EmployeeSchedules.Include(E => E.Shift).SingleOrDefaultAsync(x => x.EmployeeScheduleId == employeeSchedule.EmployeeScheduleId);
            
            return Ok(employeeSchedule);
        }

        // POST: api/EmployeeSchedules
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeSchedule>> PostEmployeeSchedule(EmployeeSchedule employeeSchedule)
        {
            _context.EmployeeSchedules.Add(employeeSchedule);
            await _context.SaveChangesAsync();

            employeeSchedule = await _context.EmployeeSchedules.Include(E => E.Shift).SingleOrDefaultAsync(x => x.EmployeeScheduleId == employeeSchedule.EmployeeScheduleId);

            return CreatedAtAction("GetEmployeeSchedule", new { id = employeeSchedule.EmployeeScheduleId }, employeeSchedule);
        }

        // DELETE: api/EmployeeSchedules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeSchedule>> DeleteEmployeeSchedule(int id)
        {
            var employeeSchedule = await _context.EmployeeSchedules.FindAsync(id);
            if (employeeSchedule == null)
            {
                return NotFound();
            }

            _context.EmployeeSchedules.Remove(employeeSchedule);
            await _context.SaveChangesAsync();

            return employeeSchedule;
        }

        private bool EmployeeScheduleExists(int id)
        {
            return _context.EmployeeSchedules.Any(e => e.EmployeeScheduleId == id);
        }
    }
}
