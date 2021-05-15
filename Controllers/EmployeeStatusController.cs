using Ezana.ShiftManagment.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;
        public EmployeeStatusController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeStatus>>> GetEmployees()
        {
            return await _context.EmployeeStatuses.ToListAsync();
        }

        
        [HttpGet("{id}", Name="GetEmployeeStatus")]
        public async Task<ActionResult<EmployeeStatus>> GetEmployee(int id)
        {
            var employee = await _context.EmployeeStatuses.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut()]
        public async Task<IActionResult> PutEmployee([FromBody]EmployeeStatus employeeStatus)
        {
            if (null == employeeStatus)
            {
                return BadRequest();
            }

            // _context.Entry(employeeStatus).State = EntityState.Modified;
            _context.EmployeeStatuses.Update(employeeStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
                
            }

            return Ok(employeeStatus);
        }

        private IActionResult BadRequest()
        {
            throw new NotImplementedException();
        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeeStatus>> PostEmployee(EmployeeStatus employeeStatus)
        {
            _context.EmployeeStatuses.Add(employeeStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeStatus", new { id = employeeStatus.Id }, employeeStatus);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeStatus>> DeleteEmployee(int id)
        {
            var employeeStatus = await _context.EmployeeStatuses.FindAsync(id);
            if (employeeStatus == null)
            {
                return NotFound();
            }

            _context.EmployeeStatuses.Remove(employeeStatus);
            await _context.SaveChangesAsync();

            return employeeStatus;
        }


    }
}
