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
    public class InsuranceFirmController : Controller
    {
        public InsuranceFirmController()
        {
            
        }
        private IPrescriptionService PrescriptionService = new PrescriptionService();
        private IModelFactory ModelFactory = new ModelFactory();


        // GET: InsuranceFirm/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: InsuranceFirm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsuranceFirmName,StreetAddress,PhoneNumber,FaxNumber,City,State,ZipCode")] InsuranceFirmModel insuranceFirmModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    int a = PrescriptionService.insuranceFirms.GetNumofCompanies(); //Getting total number of insurance Firms
                    insuranceFirmModel.InsuranceFirmID = (a + 1).ToString(); //Assigning ID
                    var insuranceFirmEntity = ModelFactory.Create(insuranceFirmModel);
                    PrescriptionService.insuranceFirms.Insert(insuranceFirmEntity);
                    TempData["notice"] = "Insurance Firm Successfully Added";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(insuranceFirmModel);
                }
            }

            return View(insuranceFirmModel);
        }

        // GET: InsuranceFirm/Search
        [HttpGet]
        [ChildActionOnly]
        public ActionResult SearchPartial()
        {
            InsuranceSearchViewModel s = new InsuranceSearchViewModel();
            s.condition = "";
            s.value = "";
            s.criteria = "";
            /*
            List<InsuranceFirmModel> p = new List<InsuranceFirmModel>();
            InsuranceFirmIndexModel model = new InsuranceFirmIndexModel(s, p);
             */ 
            var searchCategory = new SelectList(new[] { "Name", "Address", "Phone" });
            ViewBag.SearchType = searchCategory;
            return PartialView(s);
        }

        [HttpPost]
        public PartialViewResult SearchPartial(InsuranceSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<InsuranceFirm> insurances;
                    if (search.condition == "Name")
                    {
                        insurances = PrescriptionService.insuranceFirms.GetAllUsingName(search.value, search.criteria);
                    }
                    else
                        if (search.condition == "Address")
                        {
                            insurances = PrescriptionService.insuranceFirms.GetAllUsingAddress(search.value, search.criteria);
                        }
                        else
                        {
                            insurances = PrescriptionService.insuranceFirms.GetAllUsingPhoneNumber(search.value, search.criteria);
                        }

                    List<InsuranceFirmModel> insuranceFirmsModel = insurances.Select(ModelFactory.Create).ToList<InsuranceFirmModel>();
                    return PartialView("DisplayPartial", insuranceFirmsModel);
                    
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

        //GET: InsuranceFirm/Create
        public ActionResult Index()
        {
            InsuranceSearchViewModel s = new InsuranceSearchViewModel();
            s.condition = "";
            s.value = "";
            s.criteria = "";
            var searchCategory = new SelectList(new[] { "Name", "Address", "Phone" });
            ViewBag.SearchType = searchCategory;
            return View(s);
        }

        [HttpPost]
        public PartialViewResult Search(InsuranceSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<InsuranceFirm> insurances;
                    if (search.condition == "Name")
                    {
                        insurances = PrescriptionService.insuranceFirms.GetAllUsingName(search.value, search.criteria);
                    }
                    else
                        if (search.condition == "Address")
                        {
                            insurances = PrescriptionService.insuranceFirms.GetAllUsingAddress(search.value, search.criteria);
                        }
                        else
                        {
                            insurances = PrescriptionService.insuranceFirms.GetAllUsingPhoneNumber(search.value, search.criteria);
                        }

                    List<InsuranceFirmModel> insuranceFirmsModel = insurances.Select(ModelFactory.Create).ToList<InsuranceFirmModel>();
                    return PartialView("_InsuranceTablePartial", insuranceFirmsModel);

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


    }
}