using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{

    public class PharmacySearchViewModel
    {
        public string value { get; set; }
        public string condition { get; set; }
    }

    public class PharmacyModel
    {
        public string PharmacyID { get; set; }
        public string PharmacyName { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string[] PrescriptionIDs { get; set; }
        public string[] PharmacyUserIDs { get; set; }
        public string[] PatientIDs { get; set; }
        public string PharmacistID { get; set; }

        

    }
}