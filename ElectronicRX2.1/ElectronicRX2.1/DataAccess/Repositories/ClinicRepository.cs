using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class ClinicRepository : Repository<Clinic>
    {
        PrescriptionsDbContext _context;
        public ClinicRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Clinic> GetAllUsingState(string state)
        {
            return _context.Clinics.Where(d => d.State == state).ToList<Clinic>();
        }

        public List<Clinic> GetAllUsingZipCode (string zipCode)
        {
            return _context.Clinics.Where(d => d.ZipCode == zipCode).ToList<Clinic>();
        }

        public List<Clinic> GetAllUsingName(string name)
        {
            return _context.Clinics.Where(d => d.ClinicName == name).ToList<Clinic>();
        }



    }
}