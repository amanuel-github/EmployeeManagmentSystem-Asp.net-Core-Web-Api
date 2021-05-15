using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class AppTask
    {

        public int AppTaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AppTaskStatusId { get; set; }
        public int TaskPrioriyId { get; set; }
        public int TaskCategoryId { get; set; }
        public int EmployeeId { get; set; }
        public string responsible { get; set; }
    }
}
