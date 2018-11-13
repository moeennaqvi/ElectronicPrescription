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
    public class PatientController : BaseApiController
    {
        

        public PatientController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var patients = PrescriptionService.patients.Get();
                var models = patients.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var patient = PrescriptionService.patients.Get(id);
                var model = ModelFactory.Create(patient);
                return Ok(model);
            }
            catch(Exception ex)
            {
                //Logging
                return InternalServerError(ex);

            }
            
        }
        /*
        // Get api/patient?lastname=""
        [HttpGet]
        public IHttpActionResult GetLast([FromUri] string lastname)
        {
            try
            {
                var patient = _service.patients.GetUsingLastName(lastname);
                var model = _modelFactory.Create(patient);
                return Ok(model);
            }
            catch (Exception ex)
            {
                //Logging
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();
            }
        }
        */

        [HttpGet]
        public IHttpActionResult GetAllLast([FromUri] string lastname)
        {
            try
            {
                var patients = PrescriptionService.patients.GetAllUsingLastName(lastname);
                var models = patients.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                //Logging
                return InternalServerError(ex);
            }
        }


        // Get api/patient?firstname=""
        [HttpGet]
        public IHttpActionResult GetAllFirst([FromUri] string firstname)
        {
            try
            {
                var patients = PrescriptionService.patients.GetAllUsingFirstName(firstname);
                var models = patients.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                //Logging
                return InternalServerError(ex);
            }
        }

       
        [ModelValidator]
        public IHttpActionResult Post([FromBody]PatientModel patientModel)
        {
            var insuranceEntity = PrescriptionService.insuranceFirms.Get(patientModel.InsuranceFirmID);

            var patientEntity = ModelFactory.Create(patientModel, insuranceEntity);
            var patient = PrescriptionService.patients.Insert(patientEntity);
            var model = ModelFactory.Create(patient);
            return Created(string.Format("http://localhost:35718/api/patient/{0}", model.PatientID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] PatientModel patientModel)
        {
            try
            {
                InsuranceFirm insuranceEntity = PrescriptionService.insuranceFirms.Get(patientModel.InsuranceFirmID);

                List<Prescription> prescriptionEntities = new List<Prescription>();
                foreach(string id in patientModel.PrescriptionIDs)
                {
                    prescriptionEntities.Add(PrescriptionService.prescriptions.Get(id));
                }

                List<Pharmacy> pharmacyEntities = new List<Pharmacy>();
                foreach(string id in patientModel.PharmacyIDs)
                {
                    pharmacyEntities.Add(PrescriptionService.pharmacies.Get(id));
                }

                List<Drug> drugEntities = new List<Drug>();
                foreach(string id in patientModel.DrugIDs)
                {
                    drugEntities.Add(PrescriptionService.drugs.Get(id));
                }

                List<Doctor> doctorEntities = new List<Doctor>();
                foreach(string id in patientModel.DoctorIDs)
                {
                    doctorEntities.Add(PrescriptionService.doctors.Get(id));
                }
                
                var patientEntity = ModelFactory.Create(patientModel, insuranceEntity, prescriptionEntities, pharmacyEntities, drugEntities, doctorEntities);
                var patient = PrescriptionService.patients.Update(patientEntity);
                var model = ModelFactory.Create(patient);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(string id)
        {
            try
            {
                var patientEntity = PrescriptionService.patients.Get(id);
                if(patientEntity != null)
                {
                    PrescriptionService.patients.Delete(patientEntity);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
