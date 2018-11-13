using ElectronicRX2._1.DataAccess;
using ElectronicRX2._1.DataAccess.Entities;
using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicRX2._1.Controllers
{
    public class PrescriptionController : Controller
    {
        private IPrescriptionService PrescriptionService = new PrescriptionService();
        private IModelFactory ModelFactory = new ModelFactory();

        /*
        public PrescriptionController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }
        */
        // GET: Prescription
        public ActionResult Index()
        {
            return View();
        }

        // GET: Prescription/New
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        //GET: Prescription/RXSummary
        public ActionResult RXSummary()
        {
            return PartialView("RXSummary");
        }

        [HttpGet]
        public ActionResult FillRX()
        {
            var prescription = PrescriptionService.prescriptions.Get();
            var models = prescription.Select(ModelFactory.Create);
            return View(models);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult FillPartial()
        {
            PrescriptionModel model = new PrescriptionModel();
            return PartialView(model);
        }

        
        [HttpGet]
        [ChildActionOnly]
        public ActionResult FillPartial(string id)
        {
            Prescription prescriptionEntity = PrescriptionService.prescriptions.Get(id);
            Doctor doctorEntity = PrescriptionService.doctors.Get(prescriptionEntity.DoctorId);
            Pharmacy pharmacyEntity = PrescriptionService.pharmacies.Get(prescriptionEntity.PharmacyId);
            Patient patientEntity = PrescriptionService.patients.Get(prescriptionEntity.PatientId);
            Drug drugEntity = PrescriptionService.drugs.Get(prescriptionEntity.DrugId);

            PrescriptionModel prescriptionModel = ModelFactory.Create(prescriptionEntity);
            DoctorModel doctorModel = ModelFactory.Create(doctorEntity);
            PharmacyModel pharmacyModel = ModelFactory.Create(pharmacyEntity);
            PatientModel patientModel = ModelFactory.Create(patientEntity);
            DrugModel drugModel = ModelFactory.Create(drugEntity);

            PrescriptionViewModel model = new PrescriptionViewModel(prescriptionModel, doctorModel, patientModel, pharmacyModel, drugModel);
            return PartialView(model);
        }
        

        // POST: Prescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Prescription Create(Patient patient, Pharmacy pharmacy, Drug drug, PrescriptionModel prescriptionModel, Doctor doctor);
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(PrescriptionModel prescriptionModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Patient patient = PrescriptionService.patients.Get(prescriptionModel.PatientID);
                    Pharmacy pharmacy = PrescriptionService.pharmacies.Get(prescriptionModel.PharmacyID);
                    Drug drug = PrescriptionService.drugs.Get(prescriptionModel.DrugID);
                    Doctor doctor = PrescriptionService.doctors.Get(prescriptionModel.DoctorID);

                    int a = PrescriptionService.prescriptions.GetNumofPrescriptions(); //Getting total number of prescription
                    prescriptionModel.PrescriptionID = (a + 1).ToString(); //Assigning ID
                    prescriptionModel.Status = "Pending";
                    var prescriptionEntity = ModelFactory.Create(patient, pharmacy, drug, prescriptionModel, doctor);
                    PrescriptionService.prescriptions.Insert(prescriptionEntity);
                    TempData["notice"] = "Prescription Sent";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(prescriptionModel);
                }
            }

            return View(prescriptionModel);
        }


        // GET: Prescription/History
        [HttpGet]
        public ActionResult History()
        {
            return View();
        }

        // GET: Prescription/Refill
        public ActionResult Refill()
        {
            return View();
        }

        //GET: /Prescription/RXManager
        //[Authorize(Roles = "Doctor")]
        [HttpGet]
        public ActionResult RXManager()
        {
            string[] statuses = { "Successful", "Pending", "Queued", "Error", "Acknowledged Error", "Deny" };
            List<int> num = new List<int>();
            try
            {
                for (int i = 0; i < statuses.Length; i++)
                {
                    num.Add(PrescriptionService.prescriptions.GetNumUsingStatus(statuses[i]));

                }

                ViewBag.SuccessNumber = num[0];
                ViewBag.PendingNumber = num[1];
                ViewBag.QueuedNumber = num[2];
                ViewBag.ErrorNumber = num[3];
                ViewBag.AcknowledgedErrorNumber = num[4];
                ViewBag.DenyNumber = num[5];
                return View();

            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        //
        // POST: /Prescription/RXManager
        [HttpPost]
        //[Authorize(Roles = "Doctor")]
        public ActionResult RXManager(RXManagerViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(DateTime.Compare(model.startDate,model.EndDate)<0)
                {
                    string[] statuses = { "Successful", "Pending", "Queued", "Error", "Acknowledged Error", "Deny" };
                    List<int> num = new List<int>();
                    try
                    {
                        for (int i = 0; i < statuses.Length; i++)
                        {
                                num.Add(PrescriptionService.prescriptions.GetNumFromDurationandStatus(model.startDate, model.EndDate, statuses[i]));
                            
                        }

                        ViewBag.SuccessNumber = num[0];
                        ViewBag.PendingNumber = num[1];
                        ViewBag.QueuedNumber = num[2];
                        ViewBag.ErrorNumber = num[3];
                        ViewBag.AcknowledgedErrorNumber = num[4];
                        ViewBag.DenyNumber = num[5];
                        return View();

                    }
                    catch(Exception ex)
                    {
                        return View("Error");
                    }
                    

                }
                else
                {
                    return View("Error");
                }
                /*
                try
                {
                    int num = PrescriptionService.prescriptions.GetNumFromDurationandStatus(start, end, status);
                    return Ok(num);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
                */
            }
            ViewBag.SuccessNumber = 0;
            ViewBag.PendingNumber = 0;
            ViewBag.QueuedNumber = 0;
            ViewBag.ErrorNumber = 0;
            ViewBag.AcknowledgedErrorNumber = 0;
            ViewBag.DenyNumber = 0;
            return View(model);
        }

        

    }
}