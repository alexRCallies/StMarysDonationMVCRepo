using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage ="Please enter Bio")]
        [Display(Name ="Bio")]
        public string Bio { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
