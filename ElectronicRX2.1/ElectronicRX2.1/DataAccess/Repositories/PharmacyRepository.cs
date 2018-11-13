using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class PharmacyRepository : Repository<Pharmacy>
    {
        PrescriptionsDbContext _context;
        public PharmacyRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;                
        }

        public List<Pharmacy> GetAllUsingName(string pharmacyName)
        {
            return _context.Pharmacies.Where(p => p.PharmacyName == pharmacyName).ToList<Pharmacy>(); 
        }

        public List<Pharmacy> GetAllUsingStateName(string state)
        {
            return _context.Pharmacies.Where(p => p.State == state).ToList<Pharmacy>();
        }

        public List<Pharmacy> GetAllUsingZipCode(string zipCode)
        {
            return _context.Pharmacies.Where(p => p.ZipCode == zipCode).ToList<Pharmacy>();
        }
    }
}