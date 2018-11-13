using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class PatientRepository : Repository<Patient>
    {
        PrescriptionsDbContext _context;
        public PatientRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }
        /*
        public Patient GetUsingLastName(string lastName)
        {

            return _context.Patients.SingleOrDefault(patient => patient.LastName == lastName);
        }
        */
        public List<Patient> GetAllUsingLastName(string lastname)
        {
            return _context.Patients.Where(p => p.LastName == lastname).ToList<Patient>();
        }

        public List<Patient> GetAllUsingFirstName(string firstname)
        {
            return _context.Patients.Where(p => p.FirstName == firstname).ToList<Patient>();
        }

        public List<Patient> GetAllUsingAccount(string account)
        {
            return _context.Patients.Where(p => p.ID == account).ToList<Patient>();
        }
        public int GetNumofPatients()
        {
            return _context.Set<Patient>().Count();
        }
        /*
        public Patient GetUsingFirstName(string firstName)
        {
            return _context.Patients.SingleOrDefault(patient => patient.FirstName == firstName);
        }
         */
    }

}