using St.Marys_Donor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StMarys_Donor.ViewModels
{
    public class HospitalVerification
    {
        [Required(ErrorMessage ="Please Enter Hospital Name")]
        [Display(Name = "Hospital Name")]
        public string HosName { get; set; }
        [Display(Name ="Patients Needing Verification")]
        public List<Patient> Patients { get; set; }
        [Display(Name ="Is A Patient At This Hospital")]
        public bool IsVerifiedPatient { get; set; }
        [Display(Name ="Is Not A Patient At This Hospital")]
        public bool IsNotAVerifiedPatient { get; set; }
    }
}
