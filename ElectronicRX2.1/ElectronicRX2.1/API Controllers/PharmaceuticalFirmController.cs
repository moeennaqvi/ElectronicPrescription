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
    public class PharmaceuticalFirmController : BaseApiController
    {
        public PharmaceuticalFirmController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var pharmaceuticalFirms = PrescriptionService.pharmaceuticalfirms.Get();
                List<PharmaceuticalFirmModel> pharmaceuticalFirmModel = new List<PharmaceuticalFirmModel>();
                foreach(PharmaceuticalFirm pharmaceuticalFirm in pharmaceuticalFirms )
                {

                    pharmaceuticalFirmModel.Add(ModelFactory.Create(pharmaceuticalFirm));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(pharmaceuticalFirmModel);
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
                var pharmaceuticalFirm = PrescriptionService.pharmaceuticalfirms.Get(id);
                var model = ModelFactory.Create(pharmaceuticalFirm);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        // get all pharmaceutical Firms using Name
        public IHttpActionResult GetFromName(string name)
        {
            try
            {
                var pharmaceuticalFirms = PrescriptionService.pharmaceuticalfirms.GetAllUsingName(name);
                var models = pharmaceuticalFirms.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }                

        [ModelValidator]
        public IHttpActionResult Post([FromBody]PharmaceuticalFirmModel pahrmaceuticalFirmModel)
        {
            var pharmaceuticalFirmEntity = ModelFactory.Create(pahrmaceuticalFirmModel);
            var pharmaceuticalFirm = PrescriptionService.pharmaceuticalfirms.Insert(pharmaceuticalFirmEntity);
            var model = ModelFactory.Create(pharmaceuticalFirm);            
            return Created(string.Format("http://localhost:35718/api/pharmaceuticalFirm/{0}", model.PharmaceuticalFirmID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] PharmaceuticalFirmModel pharmaceuticalFirmModel)
        {
            try
            {
                List<Drug> drugEntities = new List<Drug>();
                foreach(string id in pharmaceuticalFirmModel.DrugIDs)
                {
                    drugEntities.Add(PrescriptionService.drugs.Get(id));
                }

                PharmaceuticalFirm pharmaceuticalFirmEntity = ModelFactory.Create(pharmaceuticalFirmModel, drugEntities);
                var pharmaceuticalFirm = PrescriptionService.pharmaceuticalfirms.Update(pharmaceuticalFirmEntity);
                var model = ModelFactory.Create(pharmaceuticalFirm);
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
                var pharmaceuticalFirmEntity = PrescriptionService.pharmaceuticalfirms.Get(id);
                if (pharmaceuticalFirmEntity != null)
                {
                    PrescriptionService.pharmaceuticalfirms.Delete(pharmaceuticalFirmEntity);
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
