using ElectronicRX2._1.DataAccess;
using ElectronicRX2._1.DataAccess.Entities;
using ElectronicRX2._1.Filters;
using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElectronicRX2._1.API_Controllers
{
    public class DoctorController : BaseApiController
    {
        public DoctorController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var doctors = PrescriptionService.doctors.Get();
                List<DoctorModel> doctorsModel = new List<DoctorModel>();
                foreach(Doctor doctor in doctors )
                {

                    doctorsModel.Add(ModelFactory.Create(doctor));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(doctorsModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var doctor = PrescriptionService.doctors.Get(id);
                var model = ModelFactory.Create(doctor);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        // get all doctors using first name
        public IHttpActionResult GetFromFirstName(string fname)
        {
            try
            {
                var doctors = PrescriptionService.doctors.GetAllUsingFirstName(fname);
                var models = doctors.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all doctors using Last Name
        public IHttpActionResult GetFromLastName(string lname)
        {
            try
            {
                var doctors = PrescriptionService.doctors.GetAllUsingLastName(lname);
                var models = doctors.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all doctors using ClinicName
        public IHttpActionResult GetFromClinicName(string clinicName)
        {
            try
            {
                var doctors = PrescriptionService.doctors.GetAllUsingClinic(clinicName);
                var models = doctors.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all doctors of a specific State
        public IHttpActionResult GetFromStateName(string stateName)
        {
            try
            {
                var doctors = PrescriptionService.doctors.GetAllUsingState(stateName);
                var models = doctors.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody]DoctorModel doctorModel)
        {
            Clinic clinicEnity = PrescriptionService.clinics.Get(doctorModel.ClinicID);
            var doctorEntity = ModelFactory.Create(doctorModel, clinicEnity);
            var doctor = PrescriptionService.doctors.Insert(doctorEntity);
            var model = ModelFactory.Create(doctor);            
            return Created(string.Format("http://localhost:35718/api/doctor/{0}", model.DoctorID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] DoctorModel doctorModel)
        {
            try
            {
                Clinic clinicEntity = PrescriptionService.clinics.Get(doctorModel.ClinicID);

                List<Prescription> prescriptionEntities = new List<Prescription>();
                foreach(string id in doctorModel.PrescriptionIDs)
                {
                    prescriptionEntities.Add(PrescriptionService.prescriptions.Get(id));
                }

                List<Drug> drugEntities = new List<Drug>();
                foreach(string id in doctorModel.DrugIDs)
                {
                    drugEntities.Add(PrescriptionService.drugs.Get(id));
                }

                List<Patient> patientEntities = new List<Patient>();
                foreach(string id in doctorModel.PatientIDs)
                {
                    patientEntities.Add(PrescriptionService.patients.Get(id));
                }

                Doctor doctorEntity = ModelFactory.Create(doctorModel, clinicEntity, prescriptionEntities, drugEntities, patientEntities);
                var doctor = PrescriptionService.doctors.Update(doctorEntity);
                var model = ModelFactory.Create(doctor);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(string id)
        {
            try
            {
                var doctorEntity = PrescriptionService.doctors.Get(id);
                if (doctorEntity != null)
                {
                    PrescriptionService.doctors.Delete(doctorEntity);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
