using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace St.Marys_Donor.Models
{
    public class Health_Information
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }
        public string BloodType { get; set; }
        public bool OnMedication { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool IsMale { get; set; }
        public string Ethnicity { get; set; }


    }
}
