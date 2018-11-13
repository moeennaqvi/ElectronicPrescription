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
    public class ClinicController : BaseApiController
    {
        public ClinicController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var clinics = PrescriptionService.clinics.Get();
                List<ClinicModel> clinicsModel = new List<ClinicModel>();
                foreach(Clinic clinic in clinics )
                {

                    clinicsModel.Add(ModelFactory.Create(clinic));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(clinicsModel);
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
                var clinic = PrescriptionService.clinics.Get(id);
                var model = ModelFactory.Create(clinic);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        // get all clinics of a specific state
        public IHttpActionResult GetFromStateName(string state)
        {
            try
            {
                var clinics = PrescriptionService.clinics.GetAllUsingState(state);
                var models = clinics.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all clinics of a specific zip code
        public IHttpActionResult GetFromZipCode(string zip)
        {
            try
            {
                var clinics = PrescriptionService.clinics.GetAllUsingZipCode(zip);
                var models = clinics.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody]ClinicModel clinicModel)
        {
            var clinicEntity = ModelFactory.Create(clinicModel);
            var clinic = PrescriptionService.clinics.Insert(clinicEntity);
            var model = ModelFactory.Create(clinic);            
            return Created(string.Format("http://localhost:35718/api/clinic/{0}", model.ClinicID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] ClinicModel clinicModel)
        {
            try
            {       
                Clinician clinicianEntity = PrescriptionService.clinicians.Get(clinicModel.ClinicianID);
                List<Doctor> doctorEntities = new List<Doctor>();
                foreach (string id in clinicModel.DoctorIDs)
                {
                    doctorEntities.Add(PrescriptionService.doctors.Get(id));
                }

                var clinicEntity = ModelFactory.Create(clinicModel, clinicianEntity, doctorEntities );
                var clinic = PrescriptionService.clinics.Update(clinicEntity);
                var model = ModelFactory.Create(clinic);
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
                var clinicEntity = PrescriptionService.clinics.Get(id);
                if (clinicEntity != null)
                {
                    PrescriptionService.clinics.Delete(clinicEntity);
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
