using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("Theater")]
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }

    }
}
