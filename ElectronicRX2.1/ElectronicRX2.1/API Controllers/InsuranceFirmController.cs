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
    public class InsuranceFirmController : BaseApiController
    {
        public InsuranceFirmController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var insuranceFirms = PrescriptionService.insuranceFirms.Get();
                List<InsuranceFirmModel> insuranceFirmModel = new List<InsuranceFirmModel>();
                foreach(InsuranceFirm insuranceFirm in insuranceFirms )
                {

                    insuranceFirmModel.Add(ModelFactory.Create(insuranceFirm));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(insuranceFirmModel);
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
                var insuranceFirm = PrescriptionService.insuranceFirms.Get(id);
                var model = ModelFactory.Create(insuranceFirm);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        // get all InsuranceFirms using Name
        public IHttpActionResult GetFromName(string name)
        {
            try
            {
                var insuranceFirms = PrescriptionService.insuranceFirms.GetAllUsingName(name,"All");
                var models = insuranceFirms.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all Insurance Firms using Address
        public IHttpActionResult GetFromAddress(string address)
        {
            try
            {
                var insuranceFirms = PrescriptionService.insuranceFirms.GetAllUsingAddress(address,"All");
                var models = insuranceFirms.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all InsuranceFirms using Phone Number
        public IHttpActionResult GetFromPhone(string phoneNumber)
        {
            try
            {
                var insuranceFirms = PrescriptionService.insuranceFirms.GetAllUsingPhoneNumber(phoneNumber,"All");
                var models = insuranceFirms.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }        

        [ModelValidator]
        public IHttpActionResult Post([FromBody]InsuranceFirmModel insuranceFirmModel)
        {
            var insuranceFirmEntity = ModelFactory.Create(insuranceFirmModel);
            var insuranceFirm = PrescriptionService.insuranceFirms.Insert(insuranceFirmEntity);
            var model = ModelFactory.Create(insuranceFirm);            
            return Created(string.Format("http://localhost:35718/api/insuranceFirm/{0}", model.InsuranceFirmID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] InsuranceFirmModel insuranceFirmModel)
        {
            try
            {               

                InsuranceFirm insuranceFirmEntity = ModelFactory.Create(insuranceFirmModel);
                var insuranceFirm = PrescriptionService.insuranceFirms.Update(insuranceFirmEntity);
                var model = ModelFactory.Create(insuranceFirm);
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
                var insuranceFirmEntity = PrescriptionService.insuranceFirms.Get(id);
                if (insuranceFirmEntity != null)
                {
                    PrescriptionService.insuranceFirms.Delete(insuranceFirmEntity);
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
