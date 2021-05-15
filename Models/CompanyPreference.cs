using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class CompanyPreference
    {
        public float MaximumHour { get; set; }
        public int DayStartingWeek { get; set; }
        public int CompanyId { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyPhone { get; set; }
        public DateTime? Created { get; set; }
    }
}
