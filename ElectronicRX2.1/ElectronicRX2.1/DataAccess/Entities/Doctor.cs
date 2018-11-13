﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Entities
{
    public class Doctor : EntityBase
    {
        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}