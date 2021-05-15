using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class ShiftViewModel
    {
        public int ShiftId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }


    }
}
