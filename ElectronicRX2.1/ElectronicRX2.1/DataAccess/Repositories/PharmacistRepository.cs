using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class PharmacistRepository : Repository<Pharmacist>
    {
        PrescriptionsDbContext _context;
        public PharmacistRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        public Pharmacist GetUsingEmail(string email)
        {
            return _context.Pharmacists.FirstOrDefault(d => d.Email == email);
        }

        public Pharmacy GetPharmacy(string id)
        {
            return _context.Pharmacists.Find(id).Pharmacy;
        }

        public string[] GetPharmacyInfo(string id)
        {
            string[] a = new string[2];
            a[0] = _context.Pharmacists.FirstOrDefault(i => i.Email == id).Pharmacy.ID;
            a[1] = _context.Pharmacists.FirstOrDefault(i => i.Email == id).Pharmacy.PharmacyName;
            return a;
        }
                

        public List<Pharmacist> GetAllUsingFirstName(string firstName)
        {
            return _context.Pharmacists.Where(i => i.FirstName == firstName).ToList<Pharmacist>();
        }

        public List<Pharmacist> GetAllUsingLastName(string lastName)
        {
            return _context.Pharmacists.Where(i => i.LastName == lastName).ToList<Pharmacist>();
        }

        public List<Pharmacist> GetAllUsingEmail(string email)
        {
            return _context.Pharmacists.Where(i => i.Email == email).ToList<Pharmacist>();
        }

        public List<Pharmacist> GetAllUsingPharmacyName(string name)
        {
            return _context.Pharmacists.Where(i => i.Pharmacy.PharmacyName == name).ToList<Pharmacist>();
        }
    }
}