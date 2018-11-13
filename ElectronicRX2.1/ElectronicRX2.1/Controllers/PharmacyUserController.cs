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
    public class PharmacyUserController : Controller
    {
        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();

        // GET: PharmacyUser
        [HttpGet]
        public ActionResult Index()
        {
            PharmacyUserSearchViewModel model = new PharmacyUserSearchViewModel();
            model.condition = "";
            model.value = "";
            var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email" });
            ViewBag.SearchType = searchCategory;
            return View(model);
        }

        // POST: PharmacyUser/Index
        [HttpPost]
        public PartialViewResult Index(PharmacyUserSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<PharmacyUser> pharmacyUsers;
                    if (search.condition == "First Name")
                    {
                        pharmacyUsers = PrescriptionService.pharmacyUsers.GetAllUsingFirstName(search.value);
                    }
                    else
                        if (search.condition == "Last Name")
                        {
                            pharmacyUsers = PrescriptionService.pharmacyUsers.GetAllUsingLastName(search.value);
                        }
                        else
                        {
                            pharmacyUsers = PrescriptionService.pharmacyUsers.GetAllUsingEmail(search.value);
                        }
                    var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email" });
                    ViewBag.SearchType = searchCategory;
                    
                    List<PharmacyUserModel> model = pharmacyUsers.Select(ModelFactory.Create).ToList<PharmacyUserModel>();
                    return PartialView("_PharmacyUsersTable", model);
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

        // GET: PharmacyUser/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: PharmacyUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneNumber,FaxNumber,StreetAddress,City,State,ZipCode,EmailId,FirstName,LastName,Gender,DOB,MobileNumber,PharmacyName,Password,ConfirmPassword,PharmacyID")] PharmacyUserModel pharmacyUserModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Pharmacy pharmacy = PrescriptionService.pharmacies.Get(pharmacyUserModel.PharmacyID);
                    int num = PrescriptionService.pharmacyUsers.GetNumofPharmacyUsers(); //Getting total num of pharmacy Users
                    pharmacyUserModel.PharmacyUserID = (num + 1).ToString(); //Assigning Id
                    var pharmacyUserEntity = ModelFactory.Create(pharmacyUserModel, pharmacy);
                    PrescriptionService.pharmacyUsers.Insert(pharmacyUserEntity); //PharmacyUser Inserted

                    //Now create a user for this
                    var idManager = new IdentityManager();
                    var user = pharmacyUserModel.GetUser();
                    var result = idManager.CreateUser(user, pharmacyUserModel.Password);
                    if (result)
                    {
                        idManager.AddUserToRole(pharmacyUserModel.EmailId, "PharmacyUser");
                    }
                    TempData["notice"] = "User Created Successfully";
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(pharmacyUserModel);
                }
            }
            return View(pharmacyUserModel);
        }

    }
}