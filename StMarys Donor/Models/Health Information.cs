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
        public int Age { get; set; }
        public string BloodType { get; set; }
        public bool OnMedications { get; set; }
        public bool Hasallergies { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool IsMale { get; set; }
        public string Ethnicity { get; set; }


    }
}
