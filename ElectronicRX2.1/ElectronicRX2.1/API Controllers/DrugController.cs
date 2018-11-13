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
    public class DrugController : BaseApiController
    {
        public DrugController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var drugs = PrescriptionService.drugs.Get();
                List<DrugModel> drugsModel = new List<DrugModel>();
                foreach(Drug drug in drugs )
                {
                    drugsModel.Add(ModelFactory.Create(drug));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(drugsModel);
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
                var drug = PrescriptionService.drugs.Get(id);
                var model = ModelFactory.Create(drug);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        // get all drugs using DrugName
        public IHttpActionResult GetFromDrugName(string drugName)
        {
            try
            {
                var drugs = PrescriptionService.drugs.GetAllUsingDrugName(drugName);
                var models = drugs.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all drugs using Manufacturer Name
        public IHttpActionResult GetFromManufacturerName(string firmName)
        {
            try
            {
                var drugs = PrescriptionService.drugs.GetAllUsingManufacturerName(firmName);
                var models = drugs.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody]DrugModel drugModel)
        {
            PharmaceuticalFirm pharmaceuticalFirmEntity = PrescriptionService.pharmaceuticalfirms.Get(drugModel.PharmaceuticalFirmId);
            var drugEntity = ModelFactory.Create(drugModel, pharmaceuticalFirmEntity);
            var drug = PrescriptionService.drugs.Insert(drugEntity);
            var model = ModelFactory.Create(drug);
            return Created(string.Format("http://localhost:35718/api/drug/{0}", model.DrugId), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] DrugModel drugModel)
        {
            try
            {
                PharmaceuticalFirm pharmaceuticalFirmEntity = PrescriptionService.pharmaceuticalfirms.Get(drugModel.PharmaceuticalFirmId);
                List<Prescription> prescriptionEntities = new List<Prescription>();
                foreach(string id in drugModel.PrescriptionIDs)
                {
                    prescriptionEntities.Add(PrescriptionService.prescriptions.Get(id));
                }

                List<Doctor> doctorEntities = new List<Doctor>();
                foreach(string id in drugModel.DoctorIDs)
                {
                    doctorEntities.Add(PrescriptionService.doctors.Get(id));
                }

                List<Patient> patientEntities = new List<Patient>();
                foreach(string id in drugModel.PatientIDs)
                {
                    patientEntities.Add(PrescriptionService.patients.Get(id));
                }               

                Drug drugEntity = ModelFactory.Create(drugModel, pharmaceuticalFirmEntity, prescriptionEntities, doctorEntities, patientEntities);
                var drug = PrescriptionService.drugs.Update(drugEntity);
                var model = ModelFactory.Create(drug);
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
                var drugEntity = PrescriptionService.drugs.Get(id);
                if (drugEntity != null)
                {
                    PrescriptionService.drugs.Delete(drugEntity);
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