using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess
{
    public class PrescriptionsDbContext : DbContext
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Clinician> Clinicians { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<InsuranceFirm> InsuranceFirms { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PharmaceuticalFirm> PharmaceuticalFirms { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<PharmacyUser> PharmacyUsers { get; set; }        
        public DbSet<Prescription> Prescriptions { get; set; }        

    }
}