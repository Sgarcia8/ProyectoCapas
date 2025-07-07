using Models.DTOs.Employee;
using Models.DTOs.Film;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Theater
{
    public class TheaterDTO
    {
        public int? TheaterId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public List<FilmDTOForTheater>? FilmsIdsAndNames { get; set; }
        public List<EmployeeDTOForTheater>? EmployeesIdsAndNames { get; set; }
    }
}
