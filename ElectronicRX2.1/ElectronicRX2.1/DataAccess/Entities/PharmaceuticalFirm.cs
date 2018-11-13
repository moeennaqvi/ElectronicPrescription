using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Entities
{
    public class PharmaceuticalFirm : EntityBase
    {
        
        public string PharmaceuticalFirmName { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; }
    }
}