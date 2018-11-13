using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{

    public class PrescriptionViewModel
    {

        public PrescriptionViewModel(PrescriptionModel prescriptionModel, DoctorModel doctorModel, PatientModel patientModel, PharmacyModel pharmacyModel, DrugModel drugModel)
        {
            prescription = prescriptionModel;
            doctor = doctorModel;
            patient = patientModel;
            pharmacy = pharmacyModel;
            drug = drugModel;
        }

        public PrescriptionModel prescription { get; set; }
        public DoctorModel doctor { get; set; }
        public PatientModel patient { get; set; }
        public PharmacyModel pharmacy { get; set; }
        public DrugModel drug { get; set; }
    }

    public class RXManagerViewModel
    {
        [Required]
        [Display(Name = "Starting Date")]
        public DateTime startDate { get; set; }

        [Required]
        [Display(Name = "Ending Date")]
        public DateTime EndDate { get; set; }
    }

    public class PrescriptionModel
    {
        
        public string PrescriptionID { get; set; }
        
        [Required]
        public string Comments { get; set; }
        
        [Required]
        public string SIG { get; set; }
        
        [Required]
        public string Quantity { get; set; }
        
        [Required]
        public string Days { get; set; }
        
        [Required]
        public bool DAW { get; set; }

        [Required]
        public int Refills { get; set; }

        [Required]
        public string Units { get; set; }
        
        
        public string Status { get; set; }

        [Required]
        public System.DateTime WrittenDate { get; set; }     
        
        
        [Required]
        public string PatientID { get; set; }
        
        [Required]
        public string PharmacyID { get; set; }      
        
        
        [Required]
        public string DrugID { get; set; }
        
        public string DrugName { get; set; }
        public string PatientFName { get; set; }
        public string PatientLName { get; set; }
        public string PharmacyName { get; set; }

        public string DrugWarnings { get; set; }
        public string FoodWarnings { get; set; }
        public string AllergyWarnings { get; set; }
        public string DiseaseWarnings { get; set; }
        public bool OverrideWarning { get; set; }
        public string OverrideReason { get; set; }
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }

        //public PatientModel Patient { get; set; }
        //public PharmacyModel Pharmacy { get; set; }
        //public ICollection<DrugModel> drugs { get; set; }

        

    }
}