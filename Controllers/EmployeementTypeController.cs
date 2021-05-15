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
    public class EmployeementTypeController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;
        public EmployeementTypeController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeementType>>> GetEmployees()
        {
            return await _context.EmployeementTypes.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name ="GetEmployeementType")]
        public async Task<ActionResult<EmployeementType>> GetEmployee(int id)
        {
            var employeementTypes = await _context.EmployeementTypes.FindAsync(id);

            if (employeementTypes == null)
            {
                return NotFound();
            }

            return employeementTypes;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut()]
        public async Task<IActionResult> PutEmployee([FromBody] EmployeementType employeementType)
        {
            if (null == employeementType.Id)
            {
                return BadRequest();
            }

            // _context.Entry(employeementType).State = EntityState.Modified;
            _context.EmployeementTypes.Update(employeementType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
                
            }

            return Ok(employeementType);
        }

        private IActionResult BadRequest()
        {
            throw new NotImplementedException();
        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeementType>> PostEmployee(EmployeementType employeementType)
        {
            _context.EmployeementTypes.Add(employeementType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employeementType.Id }, employeementType);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeementType>> DeleteEmployee(int id)
        {
            var employeementType = await _context.EmployeementTypes.FindAsync(id);
            if (employeementType == null)
            {
                return NotFound();
            }

            _context.EmployeementTypes.Remove(employeementType);
            await _context.SaveChangesAsync();

            return employeementType;
        }


    }
}
