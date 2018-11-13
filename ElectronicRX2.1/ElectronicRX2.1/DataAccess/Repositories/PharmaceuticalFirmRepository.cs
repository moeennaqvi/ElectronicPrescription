using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class PharmaceuticalFirmRepository : Repository<PharmaceuticalFirm>
    {
        PrescriptionsDbContext _context;
        public PharmaceuticalFirmRepository(PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        public List<PharmaceuticalFirm> GetAllUsingName(string companyName)
        {
            return _context.PharmaceuticalFirms.Where(p => p.PharmaceuticalFirmName == companyName).ToList<PharmaceuticalFirm>();
        }

        public List<PharmaceuticalFirm> GetAllUsingState(string State)
        {
            return _context.PharmaceuticalFirms.Where(p => p.State == State).ToList<PharmaceuticalFirm>();
        }

        public List<PharmaceuticalFirm> GetAllUsingZipCode(string zipCode)
        {
            return _context.PharmaceuticalFirms.Where(p => p.ZipCode == zipCode).ToList<PharmaceuticalFirm>();
        }

        public int GetNumofCompanies()
        {
            return _context.Set<PharmaceuticalFirm>().Count();
        }
    }
}