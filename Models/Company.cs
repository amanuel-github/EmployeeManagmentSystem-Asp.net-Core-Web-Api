using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyPhone { get; set; }
        public int IndustryCatogryId { get; set; }
        public DateTime? Created { get; set; }
    }
}
