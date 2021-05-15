using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class EmployeeScheduleSetting
    {
        public int EmployeeScheduleSettingId { get; set; }
        public int EmployeeId { get; set; }
    }
}
