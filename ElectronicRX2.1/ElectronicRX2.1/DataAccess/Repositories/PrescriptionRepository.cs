using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class PrescriptionRepository : Repository<Prescription>
    {
        PrescriptionsDbContext _context;
        public PrescriptionRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        
        public List<Prescription> GetAllUsingPatientFirstName(string patientFName)
        {
            return _context.Prescriptions.Where(p => p.Patient.FirstName == patientFName).ToList<Prescription>();
        }

        
        public List<Prescription> GetAllUsingPatientLastName(string patientLName)
        {
            return _context.Prescriptions.Where(p => p.Patient.LastName == patientLName).ToList<Prescription>();
        }

        
        public List<Prescription> GetAllUsingPharmacyName(string pharmacyName)
        {
            return _context.Prescriptions.Where(p => p.Pharmacy.PharmacyName == pharmacyName).ToList<Prescription>();
        }

        public List<Prescription> GetAllUsingStatus(string status)
        {
            return _context.Prescriptions.Where(p => p.Status == status).ToList<Prescription>();
        }

        public int GetNumUsingStatus(string status)
        {
            return _context.Prescriptions.Where(p => p.Status == status).Count();
        }

        public List<Prescription> GetAllinDuration(DateTime startDate, DateTime endDate)
        {
            return _context.Prescriptions.Where(p => (p.WrittenDate >= startDate && p.WrittenDate <= endDate)).ToList<Prescription>();
        }
        public int GetNumFromDurationandStatus(DateTime startDate, DateTime endDate, string status)
        {
            return _context.Prescriptions.Where(p => (p.Status == status && p.WrittenDate >= startDate && p.WrittenDate <= endDate)).Count();
        }

        public int GetNumofPrescriptions()
        {
            return _context.Set<Prescription>().Count();
        }
    }
}