using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class EmployeeScheduleViewModel
    {
        public string ScheduleName { get; set; }
        public int EmployeeScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime EndWorkingHour { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsWeekend { get; set; }
        public string RecurrenceRule { get; set; }

    }
}
