using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Entities
{
    public class Drug : EntityBase
    {
        
        public string DrugName { get; set; }
        public string DrugType { get; set; }
        public string DrugCategory { get; set; }

        public string GenericName { get; set; }
        public string ActiveIngredient { get; set; }
        public string DrugCost { get; set; }
        public string DosageQuantity { get; set; }
        public string FoodWarning { get; set; }
        public string DrugWarning { get; set; }
        public string DiseaseWarning { get; set; }
        public string AlergyWarning { get; set; }
        public string StorageUOM { get; set; }
        public string LabelDetails { get; set; }

        public bool IsavailableGeneral { get; set; }
        public bool IsOTC { get; set; } //Over the counter 
        public bool IsControlledSubstance { get; set; }

        public virtual PharmaceuticalFirm PharmaceuticalFirm { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}