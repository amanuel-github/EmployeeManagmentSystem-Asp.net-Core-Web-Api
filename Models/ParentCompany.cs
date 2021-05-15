using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class ParentCompany
    {
        public int ParentCompanyId { get; set; }
        public int IndustryCatogryId { get; set; }
        public string ParentCompanyName { get; set; }
        public string ParentCompanyAddress { get; set; }
        public string ParentCompanyTel { get; set; }
        public bool IsBranch { get; set; }

    }
}
