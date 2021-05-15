using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{

    [Auditable]
    public partial class Lookup
    {
        public Lookup()
        {
        }

        [Key]
        public int LookupId { get; set; }

        public int LookUpTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }




    public partial class LookupViewModel
    {
        public LookupViewModel()
        {
        }

        [Key]
        public int LookupId { get; set; }

        public int LookUpTypeId { get; set; }
        public string Description { get; set; }
    }
}