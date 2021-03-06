﻿using Microsoft.AspNetCore.Http;
using St.Marys_Donor.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace St.Marys_Donor.ViewModels
{
public class PatientViewModel
{
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter requirements")]
        [Display(Name = "Requirements")]
        public string Requirements { get; set; }
        [Display(Name = "Would You Like To Accept Donations")]
        public bool AcceptDonations { get; set; }
        public int Hospital_AdministratorId { get; set; }
        [Display(Name = "Hospitals")]
        public List<Hospital_Administrator> Hospital_Administrators { get; set; }
        [Required(ErrorMessage ="Please enter Bio")]
        [Display(Name ="Bio")]
        public string Bio { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
