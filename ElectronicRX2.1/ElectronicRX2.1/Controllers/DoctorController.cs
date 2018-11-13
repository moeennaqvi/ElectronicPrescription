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
    public class DoctorController : Controller
    {
        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();
        /*
        public DoctorController(IPrescriptionService prescriptionService) : base(prescriptionService)
        {
            
        }
         */ 
        // GET: Doctor
        public ActionResult Index()
        {
            DoctorSearchViewModel model = new DoctorSearchViewModel();
            model.condition = "";
            model.value = "";
            var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email" });
            ViewBag.SearchType = searchCategory;
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Index(DoctorSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Doctor> doctors;
                    if (search.condition == "First Name")
                    {
                        doctors = PrescriptionService.doctors.GetAllUsingFirstName(search.value);
                    }
                    else
                        if (search.condition == "Last Name")
                        {
                            doctors = PrescriptionService.doctors.GetAllUsingLastName(search.value);                            
                        }
                        else
                        {
                            doctors = PrescriptionService.doctors.GetAllUsingEmail(search.value);
                            
                        }
                    var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email" });
                    ViewBag.SearchType = searchCategory;

                    List<DoctorModel> model = doctors.Select(ModelFactory.Create).ToList<DoctorModel>();
                    return PartialView("_DoctorsTable", model);
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex.Message;
                    return PartialView("Error");
                }
            }
            else
            {
                ViewBag.Exception = "Model state is not Valid";
                return PartialView("Error");
            }
        }

        //GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneNumber,FaxNumber,StreetAddress,City,State,ZipCode,EmailId,FirstName,LastName,Gender,DOB,MobileNumber,ClinicName,Password,ConfirmPassword,ClinicId")] DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a user for this
                    var idManager = new IdentityManager();
                    var user = doctorModel.GetUser();
                    var result = idManager.CreateUser(user, doctorModel.Password);
                    if (result)
                    {
                        idManager.AddUserToRole(doctorModel.EmailId, "Doctor");
                        Clinic clinic = PrescriptionService.clinics.Get(doctorModel.ClinicID);
                        int num = PrescriptionService.doctors.GetNumofDoctors(); //Getting total num of Doctors
                        doctorModel.DoctorID = (num + 1).ToString(); //Assigning Id
                        var doctorEntity = ModelFactory.Create(doctorModel, clinic);
                        PrescriptionService.doctors.Insert(doctorEntity); //Doctor Inserted
                        TempData["notice"] = "User Created Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error");
                    }                    
                    
                }
                catch (Exception ex)
                {
                    return View(doctorModel);
                }
            }
            return View(doctorModel);
        }
    }
}