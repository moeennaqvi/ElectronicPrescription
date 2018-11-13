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
    public class PharmacyUserController : BaseApiController
    {
        public PharmacyUserController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }

        public IHttpActionResult Get()
        {
            try
            {
                var pharmacyUsers = PrescriptionService.pharmacyUsers.Get();
                List<PharmacyUserModel> pharmacyUsersModel = new List<PharmacyUserModel>();
                foreach(PharmacyUser pharmacyUser in pharmacyUsers )
                {

                    pharmacyUsersModel.Add(ModelFactory.Create(pharmacyUser));
                }
                //var models = drugs.Select(ModelFactory.Create);
                return Ok(pharmacyUsersModel);
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
                var pharmacyUser = PrescriptionService.pharmacyUsers.Get(id);
                var model = ModelFactory.Create(pharmacyUser);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        // get all PharmacyUsers using first name
        public IHttpActionResult GetFromFirstName(string fname)
        {
            try
            {
                var pharmacyUsers = PrescriptionService.pharmacyUsers.GetAllUsingFirstName(fname);
                var models = pharmacyUsers.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all PharmacyUsers using Last Name
        public IHttpActionResult GetFromLastName(string lname)
        {
            try
            {
                var pharmacyUsers = PrescriptionService.pharmacyUsers.GetAllUsingLastName(lname);
                var models = pharmacyUsers.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all PharmacyUsers using Pharmacy Name
        public IHttpActionResult GetFromPharmacyName(string pharmacyName)
        {
            try
            {
                var pharmacyUsers = PrescriptionService.pharmacyUsers.GetAllUsingPharmacy(pharmacyName);
                var models = pharmacyUsers.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all pharmacyUsers of a specific State
        public IHttpActionResult GetFromStateName(string stateName)
        {
            try
            {
                var pharmacyUsers = PrescriptionService.pharmacyUsers.GetAllUsingState(stateName);
                var models = pharmacyUsers.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody]PharmacyUserModel pharmacyUserModel)
        {
            Pharmacy pharmacyEntity = PrescriptionService.pharmacies.Get(pharmacyUserModel.PharmacyID);            
            
            var pharmacyUserEntity = ModelFactory.Create(pharmacyUserModel, pharmacyEntity);
            var pharmacyUser = PrescriptionService.pharmacyUsers.Insert(pharmacyUserEntity);
            var model = ModelFactory.Create(pharmacyUser);            
            return Created(string.Format("http://localhost:35718/api/pharmacyUser/{0}", model.PharmacyUserID), model);
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] PharmacyUserModel pharmacyUserModel)
        {
            try
            {
                Pharmacy pharmacyEntity = PrescriptionService.pharmacies.Get(pharmacyUserModel.PharmacyID);

                var pharmacyUserEntity = ModelFactory.Create(pharmacyUserModel, pharmacyEntity);
                var pharmacyUser = PrescriptionService.pharmacyUsers.Update(pharmacyUserEntity);
                var model = ModelFactory.Create(pharmacyUser);
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
                var pharmacyUserEntity = PrescriptionService.pharmacyUsers.Get(id);
                if (pharmacyUserEntity != null)
                {
                    PrescriptionService.pharmacyUsers.Delete(pharmacyUserEntity);
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
