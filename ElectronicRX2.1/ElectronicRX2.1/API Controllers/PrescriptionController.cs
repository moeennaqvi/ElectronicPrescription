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
    public class PrescriptionController : BaseApiController
    {
        public PrescriptionController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {

        }

        //get all prescriptions
        public IHttpActionResult Get()
        {
            var prescriptions = PrescriptionService.prescriptions.Get();
            var models = prescriptions.Select(ModelFactory.Create);
            return Ok(models);
        }

        //get prescription from id
        public IHttpActionResult Get(string id)
        {
            var prescription = PrescriptionService.prescriptions.Get(id);
            var model = ModelFactory.Create(prescription);
            return Ok(model);
        }
        
        [HttpGet]
        // get all prescriptions of a specific patient using firstName
        public IHttpActionResult GetFromPFName(string firstName)
        {
            try
            {
                var prescriptions = PrescriptionService.prescriptions.GetAllUsingPatientFirstName(firstName);
                var models = prescriptions.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        // get all prescriptions of a specific patient using lastName
        public IHttpActionResult GetFromPLName(string lastName)
        {
            try
            {
                var prescriptions = PrescriptionService.prescriptions.GetAllUsingPatientLastName(lastName);
                var models = prescriptions.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        //get all prescriptions of a specific pharmacy using pharmacyName
        public IHttpActionResult GetFromPharmacyName(string pharmacyName)
        {
            try
            {
                var prescriptions = PrescriptionService.prescriptions.GetAllUsingPharmacyName(pharmacyName);
                var models = prescriptions.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        //get all prescriptions of a specific status (e.g., Pending prescriptions)
        public IHttpActionResult GetFromStatus(string status)
        {
            try
            {
                var prescriptions = PrescriptionService.prescriptions.GetAllUsingStatus(status);
                var models = prescriptions.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        //get no. of prescriptions of a specific status (e.g., pending)
        public IHttpActionResult GetNumFromStatus(string status)
        {
            try
            {
                int num = PrescriptionService.prescriptions.GetNumUsingStatus(status);
                return Ok(num);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        //get prescriptions from a specific time interval
        public IHttpActionResult GetAllDuration([FromUri] DateTime start, DateTime end)
        {
            try
            {
                var prescriptions = PrescriptionService.prescriptions.GetAllinDuration(start, end);
                var models = prescriptions.Select(ModelFactory.Create);
                return Ok(models);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        //get number of prescriptions from a specific time interval of a specific status (e.g., pending)
        public IHttpActionResult GetNumFromStatusAndDuration([FromUri]DateTime start, DateTime end, string status)
        {
            try
            {
                int num = PrescriptionService.prescriptions.GetNumFromDurationandStatus(start, end, status);
                return Ok(num);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post([FromBody]PrescriptionModel prescriptionModel)
        {
            try
            {
                Doctor doctorEntity = PrescriptionService.doctors.Get(prescriptionModel.DoctorID);
                Patient patientEntity = PrescriptionService.patients.Get(prescriptionModel.PatientID);
                Pharmacy pharmacyEntity = PrescriptionService.pharmacies.Get(prescriptionModel.PharmacyID);
                Drug drugEntities = PrescriptionService.drugs.Get(prescriptionModel.DrugID);
                var prescriptionEntity = ModelFactory.Create(patientEntity, pharmacyEntity, drugEntities, prescriptionModel, doctorEntity);

                var prescription = PrescriptionService.prescriptions.Insert(prescriptionEntity);
                var model = ModelFactory.Create(prescription);

                return Created(string.Format("http://localhost:35718/api/prescription/{0}", model.PrescriptionID), model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] PrescriptionModel prescriptionModel)
        {
            try
            {
                Doctor doctorEntity = PrescriptionService.doctors.Get(prescriptionModel.DoctorID);
                Patient patientEntity = PrescriptionService.patients.Get(prescriptionModel.PatientID);
                Pharmacy pharmacyEntity = PrescriptionService.pharmacies.Get(prescriptionModel.PharmacyID);
                Drug drugEntities = PrescriptionService.drugs.Get(prescriptionModel.DrugID);
                var prescriptionEntity = ModelFactory.Create(patientEntity, pharmacyEntity, drugEntities, prescriptionModel, doctorEntity);
                var prescription = PrescriptionService.prescriptions.Update(prescriptionEntity);
                var model = ModelFactory.Create(prescription);
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
                var prescriptionEntity = PrescriptionService.prescriptions.Get(id);
                if (prescriptionEntity != null)
                {
                    PrescriptionService.prescriptions.Delete(prescriptionEntity);
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