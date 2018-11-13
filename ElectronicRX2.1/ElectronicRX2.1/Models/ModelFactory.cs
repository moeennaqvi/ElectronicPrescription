using ElectronicRX2._1.DataAccess.Entities;
using ElectronicRX2._1.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace ElectronicRX2._1.Models
{
    public interface IModelFactory
    {
        ClinicianModel Create(Clinician clinician);
        Clinician Create(ClinicianModel clinicianModel, Clinic clinic);

        ClinicModel Create(Clinic clinic);
        Clinic Create(ClinicModel clinicModel);
        Clinic Create(ClinicModel clinicModel, Clinician clinician, List<Doctor> doctors);

        DoctorModel Create(Doctor doctor);
        Doctor Create(DoctorModel doctorModel, Clinic clinic);
        Doctor Create(DoctorModel doctorModel, Clinic clinic, List<Prescription> prescriptions, List<Drug> drugs, List<Patient> patients);

        DrugModel Create(Drug drug);
        Drug Create(DrugModel drugModel, PharmaceuticalFirm pharmaceuticalFirm);
        Drug Create(DrugModel drugModel, PharmaceuticalFirm pharmaceuticalFirm, List<Prescription> prescriptions, List<Doctor> doctors, List<Patient> patients);

        InsuranceFirmModel Create(InsuranceFirm insuranceFirm);
        InsuranceFirm Create(InsuranceFirmModel insuranceFirmModel);
        //InsuranceFirm Create(InsuranceFirmModel insuranceFirmModel, List<Patient> patients);

        PatientModel Create(Patient patient);
        Patient Create(PatientModel patientModel, InsuranceFirm insuranceFirm);
        Patient Create(PatientModel patientModel, InsuranceFirm insuranceFirm, List<Prescription> prescriptions, List<Pharmacy> pharmacies, List<Drug> drugs, List<Doctor> doctors);

        PharmaceuticalFirmModel Create(PharmaceuticalFirm pharmaceuticalFirm);
        PharmaceuticalFirm Create(PharmaceuticalFirmModel pharmaceuticalFirmModel);
        PharmaceuticalFirm Create(PharmaceuticalFirmModel pharmaceuticalFirmModel, List<Drug> drugs);
        
        PharmacistModel Create(Pharmacist pharmacist);
        Pharmacist Create(PharmacistModel pharmacistModel, Pharmacy pharmacy);        
        
        PharmacyModel Create(Pharmacy pharmacy);
        Pharmacy Create(PharmacyModel pharmacyModel);
        Pharmacy Create(PharmacyModel pharmacyModel, List<Prescription> prescriptions, List<PharmacyUser> pharmacyUsers, Pharmacist pharmacist, List<Patient> patients);

        //List<Drug> Create(List<DrugModel> drugModel);
        //List<DrugModel> Create(List<Drug> drugs);
        
        PharmacyUserModel Create(PharmacyUser pharmacyUser);
        PharmacyUser Create(PharmacyUserModel pharmacyUserModel, Pharmacy pharmacy);
        
        PrescriptionModel Create(Prescription prescription);
        //Prescription Create(PrescriptionModel prescriptionModel);

        Prescription Create(Patient patient, Pharmacy pharmacy, Drug drug, PrescriptionModel prescriptionModel, Doctor doctor);

    }
    public class ModelFactory : IModelFactory
    {
        private UrlHelper _urlHelper;
        public ModelFactory()
        {

        }
        public ModelFactory(HttpRequestMessage message)
        {
            _urlHelper = new UrlHelper(message);
        }

        public ClinicianModel Create(Clinician clinician)
        {
            return new ClinicianModel
            {
                ClinicianID = clinician.ID,
                City = clinician.City,
                ClinicID = clinician.Clinic.ID,
                ConfirmPassword = clinician.ConfirmPassword,
                DOB = clinician.DOB,
                Email = clinician.Email,
                FaxNumber = clinician.FaxNumber,
                FirstName = clinician.FirstName,
                Gender = clinician.Gender,
                LastName = clinician.LastName,
                MobileNumber = clinician.MobileNumber,
                Password = clinician.Password,
                PhoneNumber = clinician.PhoneNumber,
                State = clinician.State,
                StreetAddress = clinician.StreetAddress,
                ZipCode = clinician.ZipCode
            };
        }

        public Clinician Create(ClinicianModel clinicianModel, Clinic clinic)
        {
            return new Clinician
            {
                City = clinicianModel.City,
                Clinic = clinic,
                ConfirmPassword = clinicianModel.ConfirmPassword,
                DOB = clinicianModel.DOB,
                Email = clinicianModel.Email,
                FaxNumber = clinicianModel.FaxNumber,
                FirstName = clinicianModel.FirstName,
                Gender = clinicianModel.Gender,
                ID = clinicianModel.ClinicianID,
                LastName = clinicianModel.LastName,
                MobileNumber = clinicianModel.MobileNumber,
                Password = clinicianModel.Password,
                PhoneNumber = clinicianModel.PhoneNumber,
                State = clinicianModel.State,
                StreetAddress = clinicianModel.StreetAddress,
                ZipCode = clinicianModel.ZipCode
            };
        }

        public ClinicModel Create(Clinic clinic)
        {
            return new ClinicModel
            {

                City = clinic.City,
                ClinicianID = clinic.Clinician.ID,
                ClinicID = clinic.ID,
                ClinicName = clinic.ClinicName,

                DoctorIDs = clinic.Doctors.Select(d => d.ID).ToArray(),
                
                FaxNumber = clinic.FaxNumber,
                PhoneNumber = clinic.PhoneNumber,
                State = clinic.State,
                StreetAddress = clinic.StreetAddress,
                ZipCode = clinic.ZipCode
            };
        }

        public Clinic Create (ClinicModel clinicModel)
        {
            return new Clinic
            {
                City = clinicModel.City,
                ClinicName = clinicModel.ClinicName,
                FaxNumber = clinicModel.FaxNumber,
                ID = clinicModel.ClinicID,
                PhoneNumber = clinicModel.PhoneNumber,
                State = clinicModel.State,
                StreetAddress = clinicModel.StreetAddress,
                ZipCode = clinicModel.ZipCode
            };
        }

        public PatientModel Create(Patient patient)
        {
            return new PatientModel
            {
                
                Address = patient.StreetAddress,
                BirthDate = patient.BirthDate,
                City = patient.City,
                FirstName = patient.FirstName,
                Gender = patient.Gender,
                HomeNumber = patient.HomeNumber,
                LastName = patient.LastName,
                MaritalStatus = patient.MaritalStatus,
                PatientID = patient.ID,
                State = patient.State,
                ZipCode = patient.ZipCode,
                InsuranceFirmID = patient.InsuranceFirmId,
                Email = patient.Email,
                InsuranceGroupNumber = patient.InsuranceGroupNumber,
                InsurancePolicyNumber = patient.InsurancePolicyNumber
            };
        }

        public Patient Create(PatientModel patientModel, InsuranceFirm insuranceFirm)
        {
            return new Patient
            {
                StreetAddress = patientModel.Address,
                BirthDate = patientModel.BirthDate,
                City = patientModel.City,
                FirstName = patientModel.FirstName,
                Gender = patientModel.Gender,
                HomeNumber = patientModel.HomeNumber,
                ID = patientModel.PatientID,
                LastName = patientModel.LastName,
                MaritalStatus = patientModel.MaritalStatus,
                State = patientModel.State,
                ZipCode = patientModel.ZipCode,
                Email = patientModel.Email,
                InsuranceFirm = insuranceFirm,
                InsuranceGroupNumber = patientModel.InsuranceGroupNumber,
                InsurancePolicyNumber = patientModel.InsurancePolicyNumber,
                InsuranceFirmId = patientModel.InsuranceFirmID
            };
        }




        public DrugModel Create(Drug drug)
        {
            return new DrugModel
            {
                ActiveIngredient = drug.ActiveIngredient,
                DiseaseWarning = drug.DiseaseWarning,
                DosageQuantity = drug.DosageQuantity,
                DrugCost = drug.DrugCost,
                DrugId = drug.ID,
                DrugName = drug.DrugName,
                DrugWarning = drug.DrugWarning,
                FoodWarning = drug.FoodWarning,
                IsavailableGeneral = drug.IsavailableGeneral,
                LabelDetails = drug.LabelDetails,
                PharmaceuticalFirmId = drug.PharmaceuticalFirm.ID,
                PharmaceuticalFirmName = drug.PharmaceuticalFirm.PharmaceuticalFirmName,
                AlergyWarning = drug.AlergyWarning,
                DrugCategory = drug.DrugCategory,
                DrugType = drug.DrugType,
                GenericName = drug.GenericName,
                IsControlledSubstance = drug.IsControlledSubstance,
                IsOTC = drug.IsOTC,
                StorageUOM = drug.StorageUOM
            };
        }

        /*
        public Drug Create(DrugModel drugModel)
        {
            return new Drug
            {
                ActiveIngredient = drugModel.ActiveIngredient,
                DiseaseWarning = drugModel.DiseaseWarning,
                DosageForm = drugModel.DosageForm,
                DrugCost = drugModel.DrugCost,
                DrugName = drugModel.DrugName,
                DrugWarning = drugModel.DrugWarning,
                FoodWarning = drugModel.FoodWarning,
                ID = drugModel.DrugId,
                IsavailableGeneral = drugModel.IsavailableGeneral,
                LabelDetails = drugModel.LabelDetails,
                RelatedDrugs = drugModel.RelatedDrugs,
                PharmaceuticalFirm = drugModel.PharmaceuticalFirmId
            };
        }
        */
        public PharmaceuticalFirm Create(PharmaceuticalFirmModel pharmaceuticalFirmModel)
        {
            return new PharmaceuticalFirm
            {
                StreetAddress = pharmaceuticalFirmModel.Address,
                City = pharmaceuticalFirmModel.City,
                FaxNumber = pharmaceuticalFirmModel.FaxNumber,
                ID = pharmaceuticalFirmModel.PharmaceuticalFirmID,
                PharmaceuticalFirmName = pharmaceuticalFirmModel.PharmaceuticalFirmName,
                PhoneNumber = pharmaceuticalFirmModel.PhoneNumber,
                State = pharmaceuticalFirmModel.State,
                ZipCode = pharmaceuticalFirmModel.ZipCode
            };
        }

        public PharmaceuticalFirmModel Create(PharmaceuticalFirm pharmaceuticalFirm)
        {
            return new PharmaceuticalFirmModel
            {
                Address = pharmaceuticalFirm.StreetAddress,
                City = pharmaceuticalFirm.City,
                FaxNumber = pharmaceuticalFirm.FaxNumber,
                PharmaceuticalFirmID = pharmaceuticalFirm.ID,
                PharmaceuticalFirmName = pharmaceuticalFirm.PharmaceuticalFirmName,
                PhoneNumber = pharmaceuticalFirm.PhoneNumber,
                State = pharmaceuticalFirm.State,
                ZipCode = pharmaceuticalFirm.ZipCode
            };
        }

        public Pharmacy Create(PharmacyModel pharmacyModel)
        {
            return new Pharmacy
            {
                StreetAddress = pharmacyModel.StreetAddress,
                City = pharmacyModel.City,
                FaxNumber = pharmacyModel.FaxNumber,
                ID = pharmacyModel.PharmacyID,
                PharmacyName = pharmacyModel.PharmacyName,
                PhoneNumber = pharmacyModel.PhoneNumber,
                State = pharmacyModel.State,
                ZipCode = pharmacyModel.ZipCode
            };
        }

        public PharmacyModel Create(Pharmacy pharmacy)
        {
            return new PharmacyModel
            {
                StreetAddress = pharmacy.StreetAddress,
                City = pharmacy.City,
                FaxNumber = pharmacy.FaxNumber,
                PharmacyID = pharmacy.ID,
                PharmacyName = pharmacy.PharmacyName,
                PhoneNumber = pharmacy.PhoneNumber,
                State = pharmacy.State,
                ZipCode = pharmacy.ZipCode
            };
        }

        /*
        public List<DrugModel> Create(List<Drug> drugs)
        {
            List<DrugModel> drugsModel = new List<DrugModel>();
            foreach(Drug drug in drugs)
            {
                drugsModel.Add(Create(drug));
            }
            return drugsModel;
        }
         */
 
        /*
        public List<Drug> Create(List<DrugModel> drugsModel)
        {
            List<Drug> drugs = new List<Drug>();
            foreach(DrugModel drugModel in drugsModel)
            {
                drugs.Add(Create(drugModel));
            }
            return drugs;
        }
        */
        /*
        public Prescription Create(PrescriptionModel prescriptionModel)
        {
                return new Prescription
                {
                     Comments = prescriptionModel.Comments, 
                     DAW = prescriptionModel.DAW, 
                     Days = prescriptionModel.Days, 
                     ID = prescriptionModel.PrescriptionId, 
                     Patient = Create(prescriptionModel.Patient), 
                     Pharmacy = Create(prescriptionModel.Pharmacy), 
                     Quantity = prescriptionModel.Quantity, 
                     Refills = prescriptionModel.Refills, 
                     SIG = prescriptionModel.SIG, 
                     Status = prescriptionModel.Status, 
                     Units = prescriptionModel.Units, 
                     WrittenDate = prescriptionModel.WrittenDate, 
                     Drug = Create(prescriptionModel.drugs.ToList())   
                };
          }
        */

        public PrescriptionModel Create(Prescription prescription)
        {
            return new PrescriptionModel
            {
                Comments = prescription.Comments,
                DAW = prescription.DAW,
                Days = prescription.Days,
                PrescriptionID = prescription.ID,
                Quantity = prescription.Quantity,
                Refills = prescription.Refills,
                SIG = prescription.SIG,
                Status = prescription.Status,
                Units = prescription.Units,
                WrittenDate = prescription.WrittenDate,
                PatientFName = prescription.Patient.FirstName,
                PatientID = prescription.Patient.ID,
                PatientLName = prescription.Patient.LastName,
                PharmacyID = prescription.Pharmacy.ID,
                PharmacyName = prescription.Pharmacy.PharmacyName,
                DrugID = prescription.DrugId,
                AllergyWarnings = prescription.AllergyWarnings,
                DiseaseWarnings = prescription.DiseaseWarnings,
                DoctorID = prescription.DoctorId,
                DoctorName = prescription.Doctor.FirstName + " " + prescription.Doctor.LastName,
                DrugName = prescription.Drug.DrugName,
                DrugWarnings = prescription.DrugWarnings,
                FoodWarnings = prescription.FoodWarnings,
                OverrideReason = prescription.OverrideReason,
                OverrideWarning = prescription.OverrideWarning
                //drugs = prescription.Drug.Select(Create).ToList(),
                //Patient = Create(prescription.Patient),
                //Pharmacy = Create(prescription.Pharmacy),
                //DrugIds = prescription.Drug.AsEnumerable().Select(r => r.ID).ToList(),
                //DrugNames = prescription.Drug.AsEnumerable().Select(r => r.DrugName).ToList()
            };
        }

        [ModelValidator]
        public Prescription Create(Patient patient, Pharmacy pharmacy, Drug drug, PrescriptionModel prescriptionModel, Doctor doctor)
        {
            return new Prescription
            {
                Comments = prescriptionModel.Comments,
                DAW = prescriptionModel.DAW,
                Days = prescriptionModel.Days,
                Drug = drug,
                ID = prescriptionModel.PrescriptionID,
                Patient = patient,
                Pharmacy = pharmacy,
                Quantity = prescriptionModel.Quantity,
                Refills = prescriptionModel.Refills,
                SIG = prescriptionModel.SIG,
                Status = prescriptionModel.Status,
                Units = prescriptionModel.Units,
                WrittenDate = prescriptionModel.WrittenDate,
                Doctor = doctor,
                AllergyWarnings = prescriptionModel.AllergyWarnings,
                DiseaseWarnings = prescriptionModel.DiseaseWarnings,
                DoctorId = prescriptionModel.DoctorID,
                DrugId = prescriptionModel.DrugID,
                DrugWarnings = prescriptionModel.DrugWarnings,
                FoodWarnings = prescriptionModel.FoodWarnings,
                PatientId = prescriptionModel.PatientID,
                PharmacyId = prescriptionModel.PharmacyID,
                OverrideReason = prescriptionModel.OverrideReason,
                OverrideWarning = prescriptionModel.OverrideWarning
            };
        }

        public DoctorModel Create(Doctor doctor)
        {
            return new DoctorModel
            {
                City = doctor.City,
                ClinicID = doctor.Clinic.ID,
                ClinicName = doctor.Clinic.ClinicName,
                ConfirmPassword = doctor.ConfirmPassword,
                DOB = doctor.DOB,
                DoctorID = doctor.ID,
                EmailId = doctor.Email,
                FaxNumber = doctor.FaxNumber,
                FirstName = doctor.FirstName,
                Gender = doctor.Gender,
                LastName = doctor.LastName,
                MobileNumber = doctor.MobileNumber,
                Password = doctor.Password,
                PhoneNumber = doctor.PhoneNumber,
                State = doctor.State,
                StreetAddress = doctor.StreetAddress,
                ZipCode = doctor.ZipCode,
                DrugIDs = doctor.Drugs.Select(d => d.ID).ToArray(),
                PatientIDs = doctor.Patients.Select(p => p.ID).ToArray(),
                PrescriptionIDs = doctor.Prescriptions.Select(p => p.ID).ToArray()
            };
        }

        public Doctor Create(DoctorModel doctorModel, Clinic clinic)
        {
            return new Doctor
            {
                City = doctorModel.City,
                Clinic = clinic,
                ConfirmPassword = doctorModel.ConfirmPassword,
                DOB = doctorModel.DOB,
                Email = doctorModel.EmailId,
                FaxNumber = doctorModel.FaxNumber,
                FirstName = doctorModel.FirstName,
                Gender = doctorModel.Gender,
                ID = doctorModel.DoctorID,
                LastName = doctorModel.LastName,
                MobileNumber = doctorModel.MobileNumber,
                Password = doctorModel.Password,
                PhoneNumber = doctorModel.PhoneNumber,
                State = doctorModel.State,
                StreetAddress = doctorModel.StreetAddress,
                ZipCode = doctorModel.ZipCode
            };
        }

        public Drug Create(DrugModel drugModel, PharmaceuticalFirm pharmaceuticalFirm)
        {
            return new Drug
            {
                ActiveIngredient = drugModel.ActiveIngredient,
                DiseaseWarning = drugModel.DiseaseWarning,
                DosageQuantity = drugModel.DosageQuantity,
                DrugCost = drugModel.DrugCost,
                DrugName = drugModel.DrugName,
                DrugWarning = drugModel.DrugWarning,
                FoodWarning = drugModel.FoodWarning,
                ID = drugModel.DrugId,
                IsavailableGeneral = drugModel.IsavailableGeneral,
                LabelDetails = drugModel.LabelDetails,
                PharmaceuticalFirm = pharmaceuticalFirm,
                AlergyWarning = drugModel.AlergyWarning,
                DrugCategory = drugModel.DrugCategory,
                DrugType = drugModel.DrugType,
                GenericName = drugModel.GenericName,
                IsControlledSubstance = drugModel.IsControlledSubstance,
                IsOTC = drugModel.IsOTC,
                StorageUOM = drugModel.StorageUOM
            };
        }

        public InsuranceFirmModel Create(InsuranceFirm insuranceFirm)
        {
            return new InsuranceFirmModel
            {
                City = insuranceFirm.City,
                FaxNumber = insuranceFirm.FaxNumber,
                InsuranceFirmID = insuranceFirm.ID,
                InsuranceFirmName = insuranceFirm.InsuranceFirmName,
                PhoneNumber = insuranceFirm.PhoneNumber,
                State = insuranceFirm.State,
                StreetAddress = insuranceFirm.StreetAddress,
                ZipCode = insuranceFirm.ZipCode
            };
        }

        public InsuranceFirm Create(InsuranceFirmModel insuranceFirmModel)
        {
            return new InsuranceFirm
            {
                City = insuranceFirmModel.City,
                FaxNumber = insuranceFirmModel.FaxNumber,
                ID = insuranceFirmModel.InsuranceFirmID,
                InsuranceFirmName = insuranceFirmModel.InsuranceFirmName,
                PhoneNumber = insuranceFirmModel.PhoneNumber,
                State = insuranceFirmModel.State,
                StreetAddress = insuranceFirmModel.StreetAddress,
                ZipCode = insuranceFirmModel.ZipCode
            };
        }        

        public Pharmacist Create(PharmacistModel pharmacistModel, Pharmacy pharmacy)
        {
            return new Pharmacist
            {
                City = pharmacistModel.City,
                ConfirmPassword = pharmacistModel.ConfirmPassword,
                DOB = pharmacistModel.DOB,
                Email = pharmacistModel.Email,
                FaxNumber = pharmacistModel.FaxNumber,
                FirstName = pharmacistModel.FirstName,
                Gender = pharmacistModel.Gender,
                ID = pharmacistModel.PharmacistID,
                LastName = pharmacistModel.LastName,
                MobileNumber = pharmacistModel.MobileNumber,
                Password = pharmacistModel.Password,
                Pharmacy = pharmacy,
                PhoneNumber = pharmacistModel.PhoneNumber,
                State = pharmacistModel.State,
                StreetAddress = pharmacistModel.StreetAddress,
                ZipCode = pharmacistModel.ZipCode
            };
        }

        public PharmacistModel Create(Pharmacist pharmacist)
        {
            return new PharmacistModel
            {
                City = pharmacist.City,
                ConfirmPassword = pharmacist.ConfirmPassword,
                ZipCode = pharmacist.ZipCode,
                StreetAddress = pharmacist.StreetAddress,
                State = pharmacist.State,
                PhoneNumber = pharmacist.PhoneNumber,
                Password = pharmacist.Password,
                MobileNumber = pharmacist.MobileNumber,
                LastName = pharmacist.LastName,
                Gender = pharmacist.Gender,
                DOB = pharmacist.DOB,
                Email = pharmacist.Email,
                FaxNumber = pharmacist.FaxNumber,
                FirstName = pharmacist.FirstName,
                PharmacistID = pharmacist.ID,
                PharmacyID = pharmacist.Pharmacy.ID,
                PharmacyName = pharmacist.Pharmacy.PharmacyName
            };
        }

        public PharmacyUser Create(PharmacyUserModel pharmacyUserModel, Pharmacy pharmacy)
        {
            return new PharmacyUser
            {
                ZipCode = pharmacyUserModel.ZipCode,
                City = pharmacyUserModel.City,
                ConfirmPassword = pharmacyUserModel.ConfirmPassword,
                DOB = pharmacyUserModel.DOB,
                Email = pharmacyUserModel.EmailId,
                FaxNumber = pharmacyUserModel.FaxNumber,
                FirstName = pharmacyUserModel.FirstName,
                Gender = pharmacyUserModel.Gender,
                ID = pharmacyUserModel.PharmacyUserID,
                LastName = pharmacyUserModel.LastName,
                MobileNumber = pharmacyUserModel.MobileNumber,
                Password = pharmacyUserModel.Password,
                Pharmacy = pharmacy,
                PhoneNumber = pharmacyUserModel.PhoneNumber,
                State = pharmacyUserModel.State,
                StreetAddress = pharmacyUserModel.StreetAddress,
                PharmacyId = pharmacy.ID
            };
        }

        public PharmacyUserModel Create(PharmacyUser pharmacyUser)
        {
            return new PharmacyUserModel
            {
                City = pharmacyUser.City,
                ConfirmPassword = pharmacyUser.ConfirmPassword,
                DOB = pharmacyUser.DOB,
                EmailId = pharmacyUser.Email,
                FaxNumber = pharmacyUser.FaxNumber,
                FirstName = pharmacyUser.FirstName,
                Gender = pharmacyUser.Gender,
                LastName = pharmacyUser.LastName,
                MobileNumber = pharmacyUser.MobileNumber,
                Password = pharmacyUser.Password,
                PharmacyID = pharmacyUser.PharmacyId,
                PharmacyUserID = pharmacyUser.ID,
                PhoneNumber = pharmacyUser.PhoneNumber,
                State = pharmacyUser.State,
                StreetAddress = pharmacyUser.StreetAddress,
                ZipCode = pharmacyUser.ZipCode
            };
        }


        public Clinic Create(ClinicModel clinicModel, Clinician clinician, List<Doctor> doctors)
        {
            return new Clinic
            {
                City = clinicModel.City,
                ClinicName = clinicModel.ClinicName,
                FaxNumber = clinicModel.FaxNumber,
                ID = clinicModel.ClinicID,
                PhoneNumber = clinicModel.PhoneNumber,
                State = clinicModel.State,
                StreetAddress = clinicModel.StreetAddress,
                ZipCode = clinicModel.ZipCode,
                Clinician = clinician,
                Doctors = doctors
            };
        }

        public Doctor Create(DoctorModel doctorModel, Clinic clinic, List<Prescription> prescriptions, List<Drug> drugs, List<Patient> patients)
        {
            return new Doctor
            {
                City = doctorModel.City,
                Clinic = clinic,
                ConfirmPassword = doctorModel.ConfirmPassword,
                DOB = doctorModel.DOB,
                Email = doctorModel.EmailId,
                FaxNumber = doctorModel.FaxNumber,
                FirstName = doctorModel.FirstName,
                Gender = doctorModel.Gender,
                ID = doctorModel.DoctorID,
                LastName = doctorModel.LastName,
                MobileNumber = doctorModel.MobileNumber,
                Password = doctorModel.Password,
                PhoneNumber = doctorModel.PhoneNumber,
                State = doctorModel.State,
                StreetAddress = doctorModel.StreetAddress,
                ZipCode = doctorModel.ZipCode,
                Drugs = drugs,
                Patients = patients,
                Prescriptions = prescriptions

            };
        }

        public Drug Create(DrugModel drugModel, PharmaceuticalFirm pharmaceuticalFirm, List<Prescription> prescriptions, List<Doctor> doctors, List<Patient> patients)
        {
            return new Drug
            {
                ActiveIngredient = drugModel.ActiveIngredient,
                DiseaseWarning = drugModel.DiseaseWarning,
                DosageQuantity = drugModel.DosageQuantity,
                DrugCost = drugModel.DrugCost,
                DrugName = drugModel.DrugName,
                DrugWarning = drugModel.DrugWarning,
                FoodWarning = drugModel.FoodWarning,
                ID = drugModel.DrugId,
                IsavailableGeneral = drugModel.IsavailableGeneral,
                LabelDetails = drugModel.LabelDetails,
                PharmaceuticalFirm = pharmaceuticalFirm,
                Doctors = doctors,
                Patients = patients,
                Prescriptions = prescriptions,
                AlergyWarning = drugModel.AlergyWarning,
                DrugCategory = drugModel.DrugCategory,
                DrugType = drugModel.DrugType,
                GenericName = drugModel.GenericName,
                IsControlledSubstance = drugModel.IsControlledSubstance,
                IsOTC = drugModel.IsOTC,
                StorageUOM = drugModel.StorageUOM
            };
            
        }
        /*
        public InsuranceFirm Create(InsuranceFirmModel insuranceFirmModel, List<Patient> patients)
        {
            return new InsuranceFirm
            {
                City = insuranceFirmModel.City,
                FaxNumber = insuranceFirmModel.FaxNumber,
                ID = insuranceFirmModel.InsuranceFirmID,
                InsuranceFirmName = insuranceFirmModel.InsuranceFirmName,
                PhoneNumber = insuranceFirmModel.PhoneNumber,
                State = insuranceFirmModel.State,
                StreetAddress = insuranceFirmModel.StreetAddress,
                ZipCode = insuranceFirmModel.ZipCode
            };
        }
        */
        public Patient Create(PatientModel patientModel, InsuranceFirm insuranceFirm, List<Prescription> prescriptions, List<Pharmacy> pharmacies, List<Drug> drugs, List<Doctor> doctors)
        {
            return new Patient
            {
                StreetAddress = patientModel.Address,
                BirthDate = patientModel.BirthDate,
                City = patientModel.City,
                FirstName = patientModel.FirstName,
                Gender = patientModel.Gender,
                HomeNumber = patientModel.HomeNumber,
                ID = patientModel.PatientID,
                LastName = patientModel.LastName,
                MaritalStatus = patientModel.MaritalStatus,
                State = patientModel.State,
                ZipCode = patientModel.ZipCode,
                Email = patientModel.Email,
                InsuranceFirm = insuranceFirm,
                InsuranceGroupNumber = patientModel.InsuranceGroupNumber,
                InsurancePolicyNumber = patientModel.InsurancePolicyNumber,
                Doctors = doctors,
                Drugs = drugs,
                Pharmacies = pharmacies,
                Prescriptions = prescriptions
            };
        }

        public PharmaceuticalFirm Create(PharmaceuticalFirmModel pharmaceuticalFirmModel, List<Drug> drugs)
        {
            return new PharmaceuticalFirm
            {
                StreetAddress = pharmaceuticalFirmModel.Address,
                City = pharmaceuticalFirmModel.City,
                FaxNumber = pharmaceuticalFirmModel.FaxNumber,
                ID = pharmaceuticalFirmModel.PharmaceuticalFirmID,
                PharmaceuticalFirmName = pharmaceuticalFirmModel.PharmaceuticalFirmName,
                PhoneNumber = pharmaceuticalFirmModel.PhoneNumber,
                State = pharmaceuticalFirmModel.State,
                ZipCode = pharmaceuticalFirmModel.ZipCode,
                Drugs = drugs
            };
        }

        public Pharmacy Create(PharmacyModel pharmacyModel, List<Prescription> prescriptions, List<PharmacyUser> pharmacyUsers, Pharmacist pharmacist, List<Patient> patients)
        {
            return new Pharmacy
            {
                StreetAddress = pharmacyModel.StreetAddress,
                City = pharmacyModel.City,
                FaxNumber = pharmacyModel.FaxNumber,
                ID = pharmacyModel.PharmacyID,
                PharmacyName = pharmacyModel.PharmacyName,
                PhoneNumber = pharmacyModel.PhoneNumber,
                State = pharmacyModel.State,
                ZipCode = pharmacyModel.ZipCode,
                Patients = patients,
                Pharmacist = pharmacist,
                PharmacyUsers = pharmacyUsers,
                Prescriptions = prescriptions
            };
        }
    }
}