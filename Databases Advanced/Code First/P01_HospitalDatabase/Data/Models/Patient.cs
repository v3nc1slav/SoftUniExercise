using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }


        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }


        [MaxLength(250)]
        [Required]
        public string Address { get; set; }


        [MaxLength(80)]
        [Required]
        public string Email { get; set; }
        public bool HasInsurance { get; set; }
        public int VisitationId { get; set; }
        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
        public int DiagnoseId { get; set; }
        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
