using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    public class RepeatType
    {
        [Key]
        public int Id { get; set; }
        public int RepeatTypeId { get; set; }
        public string RepeatName { get; set; }
        public int RepeatEvery { get; set; }
        public int RepeatEndType { get; set; }
        public int RepeatEndOcc { get; set; }
        public string RepeatEndAt { get; set; }
    }
}
