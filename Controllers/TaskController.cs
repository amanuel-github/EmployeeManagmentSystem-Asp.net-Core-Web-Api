using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ezana.ShiftManagment.API.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Ezana.ShiftManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public TasksController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppTask>>> GetEmployees()
        {
            var tasks = await _context.Task.ToListAsync();
            return tasks;
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "GetTask")]
        public async Task<ActionResult<AppTask>> GetTask(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            
            return task;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutEmployee([FromBody] AppTask appTask)
        {
            if (null == appTask)
            {
                return BadRequest();
            }

            _context.Task.Update(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = appTask.AppTaskId }, appTask);
        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Task>> PostEmployee([FromBody] AppTask appTask)
        {
            if(appTask == null)
            {
                return BadRequest();
            }

            _context.Task.Add(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = appTask.AppTaskId }, appTask);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppTask>> DeleteEmployee(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
