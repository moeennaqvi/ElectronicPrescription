using ElectronicRX2._1.DataAccess.Entities;
using ElectronicRX2._1.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicRX2._1.DataAccess
{
    public interface IPrescriptionService
    {
        //Repository<Patient> patients { get; }
        //Repository<Pharmacy> pharmacies { get; }
        //Repository<PharmaceuticalFirm> pharmaceuticalFirms { get; }
        //Repository<Drug> drugs { get; }
        //Repository<Prescription> prescriptions { get; }
        ClinicianRepository clinicians { get; }
        ClinicRepository clinics { get; }
        DoctorRepository doctors { get; }
        DrugRepository drugs { get; }
        InsuranceFirmRepository insuranceFirms { get; }
        PatientRepository patients { get; }
        PharmaceuticalFirmRepository pharmaceuticalfirms { get; }
        PharmacistRepository pharmacists { get; }
        PharmacyRepository pharmacies { get; }
        PharmacyUserRepository pharmacyUsers { get; }        
        PrescriptionRepository prescriptions { get; }
        

        
    }
}
