using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class PharmacyUserRepository : Repository<PharmacyUser>
    {
        PrescriptionsDbContext _context;
        public PharmacyUserRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetNumofPharmacyUsers()
        {
            return _context.Set<PharmacyUser>().Count();
        }

        public List<PharmacyUser> GetAllUsingFirstName(string fname)
        {
            return _context.PharmacyUsers.Where(d => d.FirstName == fname).ToList<PharmacyUser>();
        }

        public List<PharmacyUser> GetAllUsingLastName(string lname)
        {
            return _context.PharmacyUsers.Where(d => d.LastName == lname).ToList<PharmacyUser>();
        }

        public List<PharmacyUser> GetAllUsingPharmacy(string pharmacyName)
        {
            return _context.PharmacyUsers.Where(d => d.Pharmacy.PharmacyName == pharmacyName).ToList<PharmacyUser>();
        }

        public List<PharmacyUser> GetAllUsingState(string state)
        {
            return _context.PharmacyUsers.Where(d => d.State == state).ToList<PharmacyUser>();

        }

        public List<PharmacyUser> GetAllUsingEmail(string Email)
        {
            return _context.PharmacyUsers.Where(d => d.Email == Email).ToList<PharmacyUser>();
        }

        
    }
}