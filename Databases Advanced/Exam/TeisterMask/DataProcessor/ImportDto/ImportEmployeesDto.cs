using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Data.Models;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDto
    {
        [MinLength(3), MaxLength(40)]
        [RegularExpression("[A-Z]+")]
        public string Username { get; set; }

        public string Email { get; set; }

        [RegularExpression("[0-9]-[0-9]-[0-9]")]
        public string Phone { get; set; }
        public ICollection<EmployeeTask> EmployeesTasks { get; set; }
= new HashSet<EmployeeTask>();

    }

    public class Tasks
    {
        public int Task { get; set; }
    }


}
