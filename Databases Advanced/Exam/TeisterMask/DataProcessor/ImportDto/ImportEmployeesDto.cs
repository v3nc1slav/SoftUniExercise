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
        [RegularExpression("[A-Za-z0-9]+")]
        public string Username { get; set; }

        [Required]
        [EmailAddress()]
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
