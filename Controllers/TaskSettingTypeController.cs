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
    public class TaskSettingTypeController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public TaskSettingTypeController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskSettingType>>> GetTaskSettingTypes()
        {
            var tasks = await _context.TaskSettingTypes.ToListAsync();
            return tasks;
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "GetTaskSettingType")]
        public async Task<ActionResult<TaskSettingType>> GetTaskSettingType(int id)
        {
            var task = await _context.TaskSettingTypes.FindAsync(id);

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
        public async Task<IActionResult> PutTaskSettingType([FromBody] TaskSettingType appTask)
        {
            if (null == appTask)
            {
                return BadRequest();
            }

            _context.TaskSettingTypes.Update(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskSettingType", new { id = appTask.Id }, appTask);
        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TaskSettingType>> PostTaskSettingType([FromBody] TaskSettingType appTask)
        {
            if(appTask == null)
            {
                return BadRequest();
            }

            _context.TaskSettingTypes.Add(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskCategory", new { id = appTask.Id }, appTask);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskSettingType>> DeleteTaskSettingType(int id)
        {
            var task = await _context.TaskSettingTypes.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.TaskSettingTypes.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

    }
}
