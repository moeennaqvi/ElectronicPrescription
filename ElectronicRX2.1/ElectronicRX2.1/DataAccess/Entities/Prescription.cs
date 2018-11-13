using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Entities
{
    public class Prescription : EntityBase
    {
        public Prescription()
        {
            
        }
        
        public string Comments { get; set; }
        public string SIG { get; set; }
        public string Quantity { get; set; }
        public string Days { get; set; }
        public bool DAW { get; set; }
        public int Refills { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
        public System.DateTime WrittenDate { get; set; }

        public string DrugWarnings { get; set; }
        public string FoodWarnings { get; set; }
        public string AllergyWarnings { get; set; }
        public string DiseaseWarnings { get; set; }
        public bool OverrideWarning { get; set; }
        public string OverrideReason { get; set; }

        public string PatientId { get; set; }
        public string PharmacyId { get; set; }
        public string DoctorId { get; set; }
        public string DrugId { get; set; }

        [ForeignKey("DrugId")]
        public virtual Drug Drug { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("PharmacyId")]
        public virtual Pharmacy Pharmacy { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}