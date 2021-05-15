using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{

    [Auditable]
    public class ShiftAssign
    {
        public int ShiftAssignId { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndWorkHour { get; set; }
    }
}
