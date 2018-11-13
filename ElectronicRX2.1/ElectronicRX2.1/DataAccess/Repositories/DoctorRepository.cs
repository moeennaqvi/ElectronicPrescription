using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {
        PrescriptionsDbContext _context;
        public DoctorRepository( PrescriptionsDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetNumofDoctors()
        {
            return _context.Set<Doctor>().Count();
        }

        public List<Doctor> GetAllUsingFirstName(string fname)
        {
            return _context.Doctors.Where(d => d.FirstName == fname).ToList<Doctor>();
        }

        public List<Doctor> GetAllUsingLastName(string lname)
        {
            return _context.Doctors.Where(d => d.LastName == lname).ToList<Doctor>();
        }

        public List<Doctor> GetAllUsingEmail (string email)
        {
            return _context.Doctors.Where(d => d.Email == email).ToList<Doctor>();
        }

        public List<Doctor> GetAllUsingClinic (string clinicName)
        {
            return _context.Doctors.Where(d => d.Clinic.ClinicName == clinicName).ToList<Doctor>();
        }

        public List<Doctor> GetAllUsingState (string state)
        {
            return _context.Doctors.Where(d => d.State == state).ToList<Doctor>();

        }

        public Dictionary<string,string> GetAllNamesUsingClinic (string clinicName)
        {
            List<Doctor> doctors = _context.Doctors.Where(d => d.Clinic.ClinicName == clinicName).ToList<Doctor>();
            List<string> doctorNames = new List<string>();
            var a = new SelectList(doctors);
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach(Doctor doctor in doctors)
            {
                data.Add(doctor.ID, doctor.FirstName + " " + doctor.LastName);
                doctorNames.Add(doctor.FirstName + " " + doctor.LastName);
            }
            return data;
        }

        public Doctor GetUsingEmail(string email)
        {
            return _context.Doctors.FirstOrDefault(d => d.Email == email);
        }

        public string GetStateUsingEmail(string email)
        {
            return _context.Doctors.FirstOrDefault(i => i.Email == email).State;
        }

        
    }
}