using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public partial class LookupType
    {
        [Key]
        public int LookUpTypeId { get; set; }
 
        public string Description { get; set; }
       
        public ICollection<Lookup> Lookup { get; set; }
    }
}