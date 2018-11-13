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
    public class PharmacistController : BaseApiController
    {
        public PharmacistController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var pharmacists = PrescriptionService.pharmacists.Get();
                List<PharmacistModel> pharmacistsModel = new List<PharmacistModel>();
                foreach(Pharmacist pharmacist in pharmacists )
                {

                    pharmacistsModel.Add(ModelFactory.Create(pharmacist));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(pharmacistsModel);
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
                var pharmacist = PrescriptionService.pharmacists.Get(id);
                var model = ModelFactory.Create(pharmacist);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody]PharmacistModel pharmacistModel)
        {
            var pharmacyEntity = PrescriptionService.pharmacies.Get(pharmacistModel.PharmacyID);
            var pharmacistEntity = ModelFactory.Create(pharmacistModel, pharmacyEntity);
            var pharmacist = PrescriptionService.pharmacists.Insert(pharmacistEntity);
            var model = ModelFactory.Create(pharmacist);            
            return Created(string.Format("http://localhost:35718/api/pharmacist/{0}", model.PharmacistID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] PharmacistModel pharmacistModel)
        {
            try
            {
                var pharmacyEntity = PrescriptionService.pharmacies.Get(pharmacistModel.PharmacyID);
                var pharmacistEntity = ModelFactory.Create(pharmacistModel, pharmacyEntity);
                var pharmacist = PrescriptionService.pharmacists.Update(pharmacistEntity);
                var model = ModelFactory.Create(pharmacist);
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
                var pharmacistEntity = PrescriptionService.pharmacists.Get(id);
                if (pharmacistEntity != null)
                {
                    PrescriptionService.pharmacists.Delete(pharmacistEntity);
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
