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
    public class PatientController : Controller
    {
        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();
        
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            PatientSearchViewModel s = new PatientSearchViewModel();
            s.condition = "";
            s.value = "";
            var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Account Number" });
            ViewBag.SearchType = searchCategory;
            return View(s);
        }


        [HttpPost]
        public PartialViewResult Search(PatientSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Patient> patients;
                    if (search.condition == "First Name")
                    {
                        patients = PrescriptionService.patients.GetAllUsingFirstName(search.value);
                    }
                    else
                        if (search.condition == "Last Name")
                        {
                            patients = PrescriptionService.patients.GetAllUsingLastName(search.value);
                        }
                        else
                        {
                            patients = PrescriptionService.patients.GetAllUsingAccount(search.value);
                        }
                    var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Account Number" });
                    ViewBag.SearchType = searchCategory;                     
                    List<PatientModel> model = patients.Select(ModelFactory.Create).ToList<PatientModel>();
                    return PartialView("_PatientsTable",model);
                }
                catch (Exception ex)
                {
                    return PartialView("Error");
                }
            }
            else
            {
                return PartialView("Error");
            }
        }


        // GET: Patient/Search
        [HttpGet]
        [ChildActionOnly]
        public ActionResult SearchPartial()
        {
            PatientSearchViewModel s = new PatientSearchViewModel();
            s.condition = "";
            s.value = "";
            var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Account Number" });
            ViewBag.SearchType = searchCategory;
            return PartialView(s);
        }

        [HttpPost]
        public PartialViewResult SearchPartial(PatientSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Patient> patients;
                    if (search.condition == "First Name")
                    {
                        patients = PrescriptionService.patients.GetAllUsingFirstName(search.value);
                    }
                    else
                        if (search.condition == "Last Name")
                        {
                            patients = PrescriptionService.patients.GetAllUsingLastName(search.value);
                        }
                        else
                        {
                            patients = PrescriptionService.patients.GetAllUsingAccount(search.value);
                        }

                    List<PatientModel> patientsModel = patients.Select(ModelFactory.Create).ToList<PatientModel>();
                    return PartialView("DisplayPartial", patientsModel);

                }
                catch (Exception ex)
                {

                    return PartialView("Error");
                }
            }
            else
            {

                return PartialView("Error");
            }
        }


        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,MaritalStatus,Address,ZipCode,City,State,HomeNumber,Gender,Email,BirthDate,InsurancePolicyNumber,InsuranceGroupNumber,InsuranceFirmID,InsuranceFirmName,InsuranceFirmAdress,InsuranceFirmCity,InsuranceFirmState")] PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    InsuranceFirm insuranceEntity = PrescriptionService.insuranceFirms.Get(patientModel.InsuranceFirmID);
                    if(insuranceEntity == null)
                    {
                        insuranceEntity = ModelFactory.Create(patientModel.GetInsuranceModel());
                        PrescriptionService.insuranceFirms.Insert(insuranceEntity);
                    }
                    int a = PrescriptionService.patients.GetNumofPatients(); //Getting total number of patients
                    patientModel.PatientID = (a + 1).ToString(); //Assigning ID
                    var patientEntity = ModelFactory.Create(patientModel, insuranceEntity);
                    var patient = PrescriptionService.patients.Insert(patientEntity);
                    //var model = ModelFactory.Create(patient);
                    TempData["notice"] = "Patient Successfully Registered";
                    return RedirectToAction("Search");
                }
                catch(Exception ex)
                {
                    return View(patientModel);
                }
            }

            return View(patientModel);
        }
        
    }
}