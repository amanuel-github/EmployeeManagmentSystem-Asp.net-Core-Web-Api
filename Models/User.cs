using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{

   // [Auditable]
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Role> Roles { get; set; }
        //public string CompanyName { get; set; }

    }
}
