using St.Marys_Donor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace St.Marys_Donor.ViewModels
{
    public class PatientVerificationViewModel
    {
        public int PatientId { get; set; }
        [Display(Name ="Patient Name")]
        public string FullName { get; set; }
        [Display(Name = "This Person Is A Patient")]
        public bool IsVerified { get; set; }
        [Display(Name ="This Person Is Not A Patient")]
        public bool IsNotVerified { get; set; }
    }
}
