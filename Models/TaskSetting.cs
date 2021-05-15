using Ezana.ShiftManagment.API.Models.audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class TaskSetting
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskSettingTypeId { get; set; }
        public int CompanyId { get; set; }
    }
}
