using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class InsuranceFirmRepository : Repository<InsuranceFirm>
    {
        PrescriptionsDbContext _context;
        public InsuranceFirmRepository(PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        public List<InsuranceFirm> GetAllUsingName(string companyName, string criteria)
        {
            if(criteria == "All")
            {
                return _context.InsuranceFirms.Where(p => p.InsuranceFirmName == companyName).ToList<InsuranceFirm>();
            }
            else
            {
                return _context.InsuranceFirms.Where(p => (p.InsuranceFirmName == companyName) && (p.State == criteria)).ToList<InsuranceFirm>();
            }
            
        }

        public List<InsuranceFirm> GetAllUsingAddress(string address, string criteria)
        {
            if(criteria == "All")
            {
                return _context.InsuranceFirms.Where(p => p.StreetAddress.Equals(address)).ToList<InsuranceFirm>();
            }
            else
            {
                return _context.InsuranceFirms.Where(p => (p.StreetAddress == address) && (p.State == criteria)).ToList<InsuranceFirm>();
            }
            
        }

        public List<InsuranceFirm> GetAllUsingState(string state)
        {
            return _context.InsuranceFirms.Where(p => p.State.Equals(state)).ToList<InsuranceFirm>();
        }

        public List<InsuranceFirm> GetAllUsingPhoneNumber(string phone, string criteria)
        {
            if(criteria == "All")
            {

                return _context.InsuranceFirms.Where(p => p.PhoneNumber == phone).ToList<InsuranceFirm>();
            }
            else
            {
                return _context.InsuranceFirms.Where(p => (p.PhoneNumber == phone) && (p.State == criteria)).ToList<InsuranceFirm>();
            }
        }

        public int GetNumofCompanies()
        {
            return _context.Set<InsuranceFirm>().Count();
        }
    }
}