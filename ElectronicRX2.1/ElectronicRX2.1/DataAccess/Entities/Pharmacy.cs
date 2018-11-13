using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Entities
{
    public class Pharmacy : EntityBase
    {
        
        public string PharmacyName { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<PharmacyUser> PharmacyUsers { get; set; }
        public virtual Pharmacist Pharmacist { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}