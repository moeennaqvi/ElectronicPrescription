using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicRX2._1.DataAccess.Entities;
using ElectronicRX2._1.DataAccess.Repositories;
namespace ElectronicRX2._1.DataAccess
{
    public class PrescriptionService : IPrescriptionService
    {
        //private Repository<Patient> _patients;
        //private Repository<Pharmacy> _pharmacies;
        private ClinicianRepository _clinicians;
        private ClinicRepository _clinics;
        private DoctorRepository _doctors;
        private DrugRepository _drugs;
        private InsuranceFirmRepository _insuranceFirms;
        private PatientRepository _patients;
        private PharmaceuticalFirmRepository _pharmaceuticalFirms;
        private PharmacistRepository _pharmacists;
        private PharmacyRepository _pharmacies;
        private PharmacyUserRepository _pharmacyUsers;
        private PrescriptionRepository _prescriptions;
        
        PrescriptionsDbContext _context;

        public PrescriptionService()
        {
            _context = new PrescriptionsDbContext();
        }
        /*
        public Repository<Patient> patients
        {
            get 
            { 
                if(_patients== null)
                {
                    _patients = new PatientRepository(_context);
                }
                return _patients;
            }
        }
        */

        /*
        public Repository<Pharmacy> pharmacies
        {
            get 
            {
                if (_pharmacies == null)
                {
                    _pharmacies = new PharmacyRepository(_context);
                }
                return _pharmacies; 
            }
        }
         
         public Repository<PharmaceuticalFirm> pharmaceuticalFirms
        {
            get 
            { 
                if(_pharmaceuticalFirms == null)
                {
                    _pharmaceuticalFirms = new PharmaceuticalFirmRepository(_context);
                }
                return _pharmaceuticalFirms;
 
            }
        }

        public Repository<Drug> drugs
        {
            get 
            { 
                if(_drugs == null)
                {
                    _drugs = new DrugRepository(_context);
                }
                return _drugs;
            }
        }

        public Repository<Prescription> prescriptions
        {
            get 
            { 
                if(_prescriptions == null)
                {
                    _prescriptions = new PrescriptionRepository(_context);
                }
                return _prescriptions;
            }
        }
        */

        public ClinicianRepository clinicians
        {
            get
            {
                if(_clinicians == null)
                {
                    _clinicians = new ClinicianRepository(_context);
                }
                return _clinicians;
            }
        }

        public ClinicRepository clinics
        {
            get
            {
                if(_clinics == null)
                {
                    _clinics = new ClinicRepository(_context);
                }
                return _clinics;
            }
        }

        public DoctorRepository doctors
        {
            get
            {
                if (_doctors == null)
                {
                    _doctors = new DoctorRepository(_context);
                }
                return _doctors;
            }
        }

        public DrugRepository drugs
        {
            get
            {
                if (_drugs == null)
                {
                    _drugs = new DrugRepository(_context);
                }
                return _drugs;
            }
        }

        public InsuranceFirmRepository insuranceFirms
        {
            get
            {
                if (_insuranceFirms == null)
                {
                    _insuranceFirms = new InsuranceFirmRepository(_context);
                }
                return _insuranceFirms;
            }
        }

        public PatientRepository patients
        {
            get
            {
                if (_patients == null)
                {
                    _patients = new PatientRepository(_context);
                }
                return _patients;
            }
        }

        public PharmaceuticalFirmRepository pharmaceuticalfirms
        {
            get
            {
                if (_pharmaceuticalFirms == null)
                {
                    _pharmaceuticalFirms = new PharmaceuticalFirmRepository(_context);
                }
                return _pharmaceuticalFirms;
            }
        }

        public PharmacistRepository pharmacists
        {
            get
            {
                if (_pharmacists == null)
                {
                    _pharmacists = new PharmacistRepository(_context);
                }
                return _pharmacists;
            }
        }

        public PharmacyRepository pharmacies
        {
            get
            {
                if(_pharmacies == null)
                {
                    _pharmacies = new PharmacyRepository(_context);
                }
                return _pharmacies;
            }
        }

        public PharmacyUserRepository pharmacyUsers
        {
            get
            {
                if (_pharmacyUsers == null)
                {
                    _pharmacyUsers = new PharmacyUserRepository(_context);
                }
                return _pharmacyUsers;
            }
        }      
        

        public PrescriptionRepository prescriptions
        {
            get 
            { 
                if(_prescriptions == null)
                {
                    _prescriptions = new PrescriptionRepository(_context);
                }
                return _prescriptions;
            }
        }
    }
}