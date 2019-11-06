using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int MedicamentId { get; set; }
        public Medicament Medicaments { get; set; }
    }
}
