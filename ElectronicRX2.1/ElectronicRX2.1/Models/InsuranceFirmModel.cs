using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{
    public class InsuranceFirmIndexModel
    {
        public InsuranceFirmIndexModel(InsuranceSearchViewModel search, List<InsuranceFirmModel> insuranceFirms)
        {
            InsuranceFirms = insuranceFirms;
            Search = search;
        }

        public InsuranceSearchViewModel Search { get; set; }
        public List<InsuranceFirmModel> InsuranceFirms { get; set; }


    }

    public class InsuranceSearchViewModel
    {
        public string value { get; set; }
        public string condition { get; set; }
        public string criteria { get; set; }
    }

    public class InsuranceFirmModel
    {
        public string InsuranceFirmID { get; set; }

        [Required]
        public string InsuranceFirmName { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        
    }
}