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
    public class DrugController : Controller
    {

        private IPrescriptionService PrescriptionService = new PrescriptionService();
        private IModelFactory ModelFactory = new ModelFactory();

        // GET: Drug
        public ActionResult Index()
        {
            var searchCategory = new SelectList(new[] { "Name", "Active Ingredient", "Manufacturer" });
            ViewBag.SearchType = searchCategory;
            return View();
        }


        [HttpPost]
        public PartialViewResult Index(DrugSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Drug> drugs;
                    if (search.condition == "Name")
                    {
                        drugs = PrescriptionService.drugs.GetAllUsingDrugName(search.value);
                    }
                    else
                        if (search.condition == "Active Ingredient")
                        {
                            drugs = PrescriptionService.drugs.GetAllUsingIngredient(search.value);
                        }
                        else
                        {
                            drugs = PrescriptionService.drugs.GetAllUsingManufacturerName(search.value);

                        }
                    var searchCategory = new SelectList(new[] { "Name", "Active Ingredient", "Manufacturer" });
                    ViewBag.SearchType = searchCategory;

                    List<DrugModel> model = drugs.Select(ModelFactory.Create).ToList<DrugModel>();
                    return PartialView("_DrugsTable", model);
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

        // GET: InsuranceFirm/Search
        [HttpGet]
        [ChildActionOnly]
        public ActionResult SearchPartial()
        {
            DrugSearchViewModel s = new DrugSearchViewModel();
            s.condition = "";
            s.value = "";
            var searchCategory = new SelectList(new[] { "Name", "Active Ingredient", "Manufacturer" });
            ViewBag.SearchType = searchCategory;
            return PartialView(s);
        }

        [HttpPost]
        public PartialViewResult SearchPartial(DrugSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Drug> drugs;
                    if (search.condition == "Name")
                    {
                        drugs = PrescriptionService.drugs.GetAllUsingDrugName(search.value);
                    }
                    else
                        if (search.condition == "Active Ingredient")
                        {
                            drugs = PrescriptionService.drugs.GetAllUsingIngredient(search.value);
                        }
                        else
                        {
                            drugs = PrescriptionService.drugs.GetAllUsingManufacturerName(search.value);
                        }

                    List<DrugModel> drugssModel = drugs.Select(ModelFactory.Create).ToList<DrugModel>();
                    return PartialView("DisplayPartial", drugssModel);

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

        public ActionResult Create()
        {
            SelectList drugCategory;
            drugCategory = new SelectList(
                new[] 
                { 
                    "allergenics",  "anti-infectives", 
                    "antineoplastics", "biologicals", 
                    "cardiovascular agents", "central nervous system agents",
                    "coagulation modifiers", "gastrointestinal agents",
                    "genitourinary tract agents", "hormones",
                    "immunologic agents", "metabolic agents",
                    "antidotes",
                    "antipsoriatics",
                    "antirheumatics",
                    "chelating agents",
                    "cholinergic muscle stimulants",
                    "illicit (street) drugs",
                    "local injectable anesthetics",
                    "phosphate binders",
                    "psoralens",
                    "smoking cessation agents",
                    "viscosupplementation agents",
                    "nutritional products",
                    "plasma expanders",
                    "psychotherapeutic agents",
                    "radiologic agents",
                    "respiratory agents",
                    "topical agents"
                });
            ViewBag.DrugCategory = drugCategory;
            SelectList drugType = new SelectList(new[] {"Bag","Cap","Cream","Gel","Liquid","Powder","Tablet" });
            ViewBag.DrugType = drugType;
            return View();
        }

        // POST: Drug/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DrugModel drugModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    PharmaceuticalFirm company = PrescriptionService.pharmaceuticalfirms.Get(drugModel.PharmaceuticalFirmId);

                    int a = PrescriptionService.drugs.GetNumofDrugs(); //Getting total number of drugs
                    drugModel.DrugId = (a + 1).ToString(); //Assigning ID
                    var drugEntity = ModelFactory.Create(drugModel, company);
                    PrescriptionService.drugs.Insert(drugEntity);
                    TempData["notice"] = "Drug Successfully Added";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(drugModel);
                }
            }

            return View(drugModel);
        }
    }
}