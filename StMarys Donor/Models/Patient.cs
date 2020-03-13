using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace St.Marys_Donor.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Requirements { get; set; }
        public string ProfilePicture { get; set; }
        public bool AcceptingDonations { get; set; }
        public bool IsVerified { get; set; }
        public List<Patient> Patients { get; set; }
        public int? Hospital_AdministratorId { get; set; }
        [ForeignKey("Hospital_AdministratorId")]
        public virtual Hospital_Administrator Hospital_Administrators { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
      
        public Patient()
        {
            FullName = FirstName + " " + LastName;
            Patients = new List<Patient>();
        }

    }
}
