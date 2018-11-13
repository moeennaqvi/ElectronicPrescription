using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class ClinicianRepository : Repository<Clinician>
    {
        PrescriptionsDbContext _context;
        public ClinicianRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        public Clinic GetClinic(string email)
        {
            return _context.Clinicians.FirstOrDefault(d => d.Email == email).Clinic;
            //return _context.Clinicians.Find(email).Clinic;
        }

        public List<Clinician> GetAllUsingFirstName(string firstName)
        {
            return _context.Clinicians.Where(i => i.FirstName == firstName).ToList<Clinician>();
        }

        public List<Clinician> GetAllUsingLastName(string lastName)
        {
            return _context.Clinicians.Where(i => i.LastName == lastName).ToList<Clinician>();
        }

        public List<Clinician> GetAllUsingEmail(string email)
        {
            return _context.Clinicians.Where(i => i.Email == email).ToList<Clinician>();
        }

        public List<Clinician> GetAllUsingClinicName(string name)
        {
            return _context.Clinicians.Where(i => i.Clinic.ClinicName == name).ToList<Clinician>();
        }

        public string GetStateUsingEmail(string email)
        {
            return _context.Clinicians.FirstOrDefault(i => i.Email == email).State;
        }

        public Clinician GetUsingEmail(string email)
        {
            return _context.Clinicians.FirstOrDefault(i => i.Email == email);
        }
    }
}