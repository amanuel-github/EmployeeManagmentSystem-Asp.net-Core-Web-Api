using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class AppTaskStatus
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
