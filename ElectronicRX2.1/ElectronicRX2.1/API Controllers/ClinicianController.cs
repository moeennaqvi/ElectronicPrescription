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
    public class ClinicianController : BaseApiController
    {
        public ClinicianController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var clinicians = PrescriptionService.clinicians.Get();
                List<ClinicianModel> cliniciansModel = new List<ClinicianModel>();
                foreach(Clinician clinician in clinicians )
                {

                    cliniciansModel.Add(ModelFactory.Create(clinician));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(cliniciansModel);
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
                var clinician = PrescriptionService.clinicians.Get(id);
                var model = ModelFactory.Create(clinician);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody]ClinicianModel clinicianModel)
        {
            var clinicEntity = PrescriptionService.clinics.Get(clinicianModel.ClinicID);
            var clinicianEntity = ModelFactory.Create(clinicianModel, clinicEntity);
            var clinician = PrescriptionService.clinicians.Insert(clinicianEntity);
            var model = ModelFactory.Create(clinician);            
            return Created(string.Format("http://localhost:35718/api/clinician/{0}", model.ClinicianID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] ClinicianModel clinicianModel)
        {
            try
            {
                var clinicEntity = PrescriptionService.clinics.Get(clinicianModel.ClinicID);
                var clinicianEntity = ModelFactory.Create(clinicianModel, clinicEntity);
                var clinician = PrescriptionService.clinicians.Update(clinicianEntity);
                var model = ModelFactory.Create(clinician);
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
                var clinicianEntity = PrescriptionService.clinicians.Get(id);
                if (clinicianEntity != null)
                {
                    PrescriptionService.clinicians.Delete(clinicianEntity);
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
