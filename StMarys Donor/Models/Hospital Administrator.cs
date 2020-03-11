using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace St.Marys_Donor.Models
{
    public class Hospital_Administrator
    {
        [Key]
        public int Id { get; set; }
        public string HosName { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserID { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
