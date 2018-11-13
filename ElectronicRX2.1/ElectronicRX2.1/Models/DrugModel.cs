using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{

    public class DrugSearchViewModel
    {
        public string condition { get; set; }
        public string value { get; set; }
    }

    public class DrugModel
    {
        public string DrugId { get; set; }
        public string DrugName { get; set; }
        public string GenericName { get; set; }
        public string DrugType { get; set; }
        public string DrugCategory { get; set; }
        public string ActiveIngredient { get; set; }
        public string DrugCost { get; set; }
        public string DosageQuantity { get; set; }
        public string FoodWarning { get; set; }
        public string DrugWarning { get; set; }
        public string AlergyWarning { get; set; }
        public string DiseaseWarning { get; set; }
        public string StorageUOM { get; set; }
        public string LabelDetails { get; set; }

        public bool IsavailableGeneral { get; set; }
        public bool IsControlledSubstance { get; set; }
        public bool IsOTC { get; set; }
        
        
        public string PharmaceuticalFirmId { get; set; }
        public string PharmaceuticalFirmName { get; set; }
        
        public string[] PrescriptionIDs { get; set; }
        public string[] DoctorIDs { get; set; }
        public string[] PatientIDs { get; set; }
    }
}