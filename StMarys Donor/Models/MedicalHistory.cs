using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace St.Marys_Donor.Models
{
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }
        [Display(Name = "Medications")]
        public bool? OnMedications { get; set; }
        [Display(Name = "Allergies")]
        public bool? Hasallergies { get; set; }
        [Display(Name = "Gender")]
        public bool? IsMale { get; set; }
        public string Ethnicity { get; set; }


    }
}
