using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{

    public class ClinicSearchViewModel
    {
        public string value { get; set; }
        public string condition { get; set; }
    }

    public class ClinicModel
    {
        public string ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string[] DoctorIDs { get; set; }
        public string ClinicianID { get; set; }

        
    }
}