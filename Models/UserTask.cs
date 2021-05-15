using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class UserTask
    {
        public int UserTaskId { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
    }
}
