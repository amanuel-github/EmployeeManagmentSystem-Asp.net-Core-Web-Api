using Ezana.ShiftManagment.API.Models.audit;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ezana.ShiftManagment.API.Models
{
    [Auditable]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string Tel { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public int EmployeementTypeId { get; set; }
        public bool status { get; set; }
        public int EmployeeType { get; set; }
        public byte[]? EmployeePic { get; set; }
    }
}
