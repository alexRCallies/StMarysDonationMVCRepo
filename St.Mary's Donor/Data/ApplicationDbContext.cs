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
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Donor" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Patient" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Hospital Administrator" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin" });
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Health_Information> Health_Information { get; set; }
        public DbSet<Hospital_Administrator> Hospital_Administrators { get; set; }
        public DbSet<Patient> Patients { get; set; }

    }
}
