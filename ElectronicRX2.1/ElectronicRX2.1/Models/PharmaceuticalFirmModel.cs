using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{

    public class PharmaceuticalSearchViewModel
    {
        public string value { get; set; }
        public string condition { get; set; }
    }

    public class PharmaceuticalFirmModel
    {
        public string PharmaceuticalFirmID { get; set; }
        public string PharmaceuticalFirmName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string[] DrugIDs { get; set; }
    }
}