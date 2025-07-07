using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Employee
{
    public class EmployeeDTO
    {
        public int? EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public int TheaterId { get; set; }
    }
}
