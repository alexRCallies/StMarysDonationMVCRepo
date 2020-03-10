using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using St.Marys_Donor.Models;

namespace St.Marys_Donor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Donor", NormalizedName = "DONOR" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Patient", NormalizedName = "PATIENT"});
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Hospital Administrator", NormalizedName = "HOSPITAL ADMINISTRATOR" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }
        public DbSet<Hospital_Administrator> Hospital_Administrators { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogUpdate> BlogUpdates { get; set; }

    }
}
