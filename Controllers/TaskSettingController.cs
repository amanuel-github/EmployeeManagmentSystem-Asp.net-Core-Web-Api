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
    public class TaskSettingController : ControllerBase
    {
        private readonly ShiftPowerDbContext _context;

        public TaskSettingController(ShiftPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskSetting>>> GetTaskSettings()
        {
            var tasks = await _context.TaskSettings.OrderBy( x => x.TaskSettingTypeId).ToListAsync();
            return tasks;
        }

        [HttpGet("GetTaskSettingByType/{taskSettingTypeId}")]
        public async Task<ActionResult<IEnumerable<TaskSetting>>> GetTaskSettingByType(int taskSettingTypeId)
        {
            var tasks = await _context.TaskSettings.Where(x => x.TaskSettingTypeId == taskSettingTypeId).OrderBy(x => x.Id).ToListAsync();
            return tasks;
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "GetTaskSettings")]
        public async Task<ActionResult<TaskSetting>> GetTaskSetting(int id)
        {
            var task = await _context.TaskSettings.FindAsync(id);

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
        public async Task<IActionResult> PutTaskPriority([FromForm] TaskSetting appTask)
        {
            if (null == appTask)
            {
                return BadRequest();
            }

            _context.TaskSettings.Update(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskSettings", new { id = appTask.Id }, appTask);
        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TaskSetting>> PostEmployee([FromForm] TaskSetting appTask)
        {
            if(appTask == null)
            {
                return BadRequest();
            }

            _context.TaskSettings.Add(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskSettings", new { id = appTask.Id }, appTask);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskSetting>> DeleteTaskPriority(int id)
        {
            var task = await _context.TaskSettings.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.TaskSettings.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

    }
}
