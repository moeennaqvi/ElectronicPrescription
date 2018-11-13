using ElectronicRX2._1.DataAccess;
using ElectronicRX2._1.DataAccess.Entities;
using ElectronicRX2._1.Filters;
using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ElectronicRX2._1.API_Controllers
{
    public class PharmacyController : BaseApiController
    {
        public PharmacyController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
 
        }

        public IHttpActionResult Get()
        {
            try
            {
                var pharmacies = PrescriptionService.pharmacies.Get();
                var models = pharmacies.Select(ModelFactory.Create);
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
                var pharmacy = PrescriptionService.pharmacies.Get(id);
                var model = ModelFactory.Create(pharmacy);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetFromName([FromUri]string pharmacyName)
        {
            try
            {
                var pharmacies = PrescriptionService.pharmacies.GetAllUsingName(pharmacyName);
                var models = pharmacies.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetFromState([FromUri]string state)
        {
            try
            {
                var pharmacies = PrescriptionService.pharmacies.GetAllUsingStateName(state);
                var models = pharmacies.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetFromZipCode([FromUri]string zipCode)
        {
            try
            {
                var pharmacies = PrescriptionService.pharmacies.GetAllUsingZipCode(zipCode);
                var models = pharmacies.Select(ModelFactory.Create);
                return Ok(models);

            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody]PharmacyModel pharmacyModel)
        {
            var pharmacyEntity = ModelFactory.Create(pharmacyModel);
            var pharmacy = PrescriptionService.pharmacies.Insert(pharmacyEntity);
            var model = ModelFactory.Create(pharmacy);
            return Created(string.Format("http://localhost:35718/api/pharmacy/{0}", model.PharmacyID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] PharmacyModel pharmacyModel)
        {
            try
            {
                List<Prescription> prescriptionEntities = new List<Prescription>();
                foreach(string id in pharmacyModel.PrescriptionIDs)
                {
                    prescriptionEntities.Add(PrescriptionService.prescriptions.Get(id));
                }

                List<PharmacyUser> pharmacyUserEntities = new List<PharmacyUser>();
                foreach(string id in pharmacyModel.PharmacyUserIDs)
                {
                    pharmacyUserEntities.Add(PrescriptionService.pharmacyUsers.Get(id));
                }

                Pharmacist pharmacistEntity = PrescriptionService.pharmacists.Get(pharmacyModel.PharmacistID);

                List<Patient> patientEntities = new List<Patient>();
                foreach(string id in pharmacyModel.PatientIDs)
                {
                    patientEntities.Add(PrescriptionService.patients.Get(id));
                }


                

                var pharmacyEntity = ModelFactory.Create(pharmacyModel, prescriptionEntities, pharmacyUserEntities, pharmacistEntity, patientEntities);
                var pharmacy = PrescriptionService.pharmacies.Update(pharmacyEntity);
                var model = ModelFactory.Create(pharmacy);
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
                var pharmacyEntity = PrescriptionService.pharmacies.Get(id);
                if (pharmacyEntity != null)
                {
                    PrescriptionService.pharmacies.Delete(pharmacyEntity);
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