using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.Models
{
    public class NewPatientIndexModel
    {
        public NewPatientIndexModel(InsuranceFirmIndexModel insurance, PatientModel patient)
        {
            InsuranceFirmIndex = insurance;
            Patient = patient;
        }

        public InsuranceFirmIndexModel InsuranceFirmIndex { get; set; }
        public PatientModel Patient { get; set; }
    }


    public class PatientIndexModel
    {
        public PatientIndexModel(PatientSearchViewModel search, List<PatientModel> patients)
        {
            Patients = patients;
            Search = search;
        }

        public PatientSearchViewModel Search { get; set; }
        public List<PatientModel> Patients { get; set; }


    }

    public class PatientSearchViewModel
    {
        public string value { get; set; }
        public string condition { get; set; }
    }

    public class PatientModel
    {
        public string PatientID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HomeNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        [Required]
        public System.DateTime BirthDate { get; set; }

        public string InsuranceFirmID { get; set; }
        public string InsuranceFirmName { get; set; }
        public string InsuranceFirmAdress { get; set; }
        public string InsuranceFirmCity { get; set; }
        public string InsuranceFirmState { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public string InsuranceGroupNumber { get; set; }


        public string[] PrescriptionIDs { get; set; }
        public string[] PharmacyIDs { get; set; }
        public string[] DrugIDs { get; set; }
        public string[] DoctorIDs { get; set; }

        public InsuranceFirmModel GetInsuranceModel()
        {
            InsuranceFirmModel model = new InsuranceFirmModel()
            {
                InsuranceFirmID = this.InsuranceFirmID,
                City = this.InsuranceFirmCity,
                InsuranceFirmName = this.InsuranceFirmName,
                State = this.InsuranceFirmState,
                StreetAddress = this.InsuranceFirmAdress
            };
            return model;
        }





    }
}