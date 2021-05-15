using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{

    //[Auditable]
    public class Role
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
