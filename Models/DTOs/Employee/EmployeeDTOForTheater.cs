using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Employee
{
    public class EmployeeDTOForTheater
    {
        public int EmployeeId { get; set; }
        public required string FirstName { get; set; }
    }
}
