using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Entities
{
    public class Patient : EntityBase
    {
        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MaritalStatus { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HomeNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthDate { get; set; }

        public string InsurancePolicyNumber { get; set; }
        public string InsuranceGroupNumber { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Pharmacy> Pharmacies { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public string InsuranceFirmId { get; set; }
        [ForeignKey("InsuranceFirmId")]
        public InsuranceFirm InsuranceFirm { get; set; }

    }
}