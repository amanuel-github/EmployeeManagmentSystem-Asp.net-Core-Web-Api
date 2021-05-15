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
    public class EmployeeScheduleSettingsController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public EmployeeScheduleSettingsController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeScheduleSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeScheduleSetting>>> GetEmployeeScheduleSettings()
        {
            return await _context.EmployeeScheduleSettings.ToListAsync();
        }

        // GET: api/EmployeeScheduleSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeScheduleSetting>> GetEmployeeScheduleSetting(int id)
        {
            var employeeScheduleSetting = await _context.EmployeeScheduleSettings.FindAsync(id);

            if (employeeScheduleSetting == null)
            {
                return NotFound();
            }

            return employeeScheduleSetting;
        }

        // PUT: api/EmployeeScheduleSettings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeScheduleSetting(int id, EmployeeScheduleSetting employeeScheduleSetting)
        {
            if (id != employeeScheduleSetting.EmployeeScheduleSettingId)
            {
                return BadRequest();
            }

            _context.Entry(employeeScheduleSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeScheduleSettingExists(id))
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

        // POST: api/EmployeeScheduleSettings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeScheduleSetting>> PostEmployeeScheduleSetting(EmployeeScheduleSetting employeeScheduleSetting)
        {
            _context.EmployeeScheduleSettings.Add(employeeScheduleSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeScheduleSetting", new { id = employeeScheduleSetting.EmployeeScheduleSettingId }, employeeScheduleSetting);
        }

        // DELETE: api/EmployeeScheduleSettings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeScheduleSetting>> DeleteEmployeeScheduleSetting(int id)
        {
            var employeeScheduleSetting = await _context.EmployeeScheduleSettings.FindAsync(id);
            if (employeeScheduleSetting == null)
            {
                return NotFound();
            }

            _context.EmployeeScheduleSettings.Remove(employeeScheduleSetting);
            await _context.SaveChangesAsync();

            return employeeScheduleSetting;
        }

        private bool EmployeeScheduleSettingExists(int id)
        {
            return _context.EmployeeScheduleSettings.Any(e => e.EmployeeScheduleSettingId == id);
        }
    }
}
