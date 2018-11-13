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

    public class PharmaceuticalFirmController : Controller
    {

        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();

        // GET: PharmaceuticalFirm
        public ActionResult Index()
        {
            PharmaceuticalSearchViewModel model = new PharmaceuticalSearchViewModel();
            model.condition = "";
            model.value = "";
            var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
            ViewBag.SearchType = searchCategory;
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(PharmaceuticalSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<PharmaceuticalFirm> pharmaceuticalFirms = new List<PharmaceuticalFirm>();

                    if (search.condition == "Name")
                    {
                        pharmaceuticalFirms = PrescriptionService.pharmaceuticalfirms.GetAllUsingName(search.value);

                    }
                    else
                        if (search.condition == "State")
                        {
                            pharmaceuticalFirms = PrescriptionService.pharmaceuticalfirms.GetAllUsingState(search.value);
                        }
                        else
                        {
                            pharmaceuticalFirms = PrescriptionService.pharmaceuticalfirms.GetAllUsingZipCode(search.value);
                        }

                    List<PharmaceuticalFirmModel> model = pharmaceuticalFirms.Select(ModelFactory.Create).ToList<PharmaceuticalFirmModel>();
                    var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
                    ViewBag.SearchType = searchCategory;
                    return PartialView("_PharmaceuticalTablePartial", model);
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

        // GET: PharmaceuticalFirm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PharmaceuticalFirm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PharmaceuticalFirmName,Address,PhoneNumber,FaxNumber,City,State,ZipCode")] PharmaceuticalFirmModel pharmaceuticalFirmModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    int a = PrescriptionService.pharmaceuticalfirms.GetNumofCompanies(); //Getting total number of pharmaceutical Firms
                    pharmaceuticalFirmModel.PharmaceuticalFirmID = (a + 1).ToString(); //Assigning ID
                    var pharmaceuticalFirmEntity = ModelFactory.Create(pharmaceuticalFirmModel);
                    PrescriptionService.pharmaceuticalfirms.Insert(pharmaceuticalFirmEntity);
                    //var model = ModelFactory.Create(patient);
                    TempData["notice"] = "Pharmaceutical Firm Successfully Added";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(pharmaceuticalFirmModel);
                }
            }

            return View(pharmaceuticalFirmModel);
        }


        // GET: PharmaceuticalFirm/Search
        [HttpGet]
        [ChildActionOnly]
        public ActionResult SearchPartial()
        {
            PharmaceuticalSearchViewModel s = new PharmaceuticalSearchViewModel();
            s.condition = "";
            s.value = "";
            var searchCategory = new SelectList(new[] { "Name", "State", "ZipCode" });
            ViewBag.SearchType = searchCategory;
            return PartialView(s);
        }


        [HttpPost]
        public PartialViewResult SearchPartial(PharmaceuticalSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<PharmaceuticalFirm> pharmaceuticals;
                    if (search.condition == "Name")
                    {
                        pharmaceuticals = PrescriptionService.pharmaceuticalfirms.GetAllUsingName(search.value);
                    }
                    else
                        if (search.condition == "State")
                        {
                            pharmaceuticals = PrescriptionService.pharmaceuticalfirms.GetAllUsingState(search.value);
                        }
                        else
                        {
                            pharmaceuticals = PrescriptionService.pharmaceuticalfirms.GetAllUsingZipCode(search.value);
                        }

                    List<PharmaceuticalFirmModel> pharmaceuticalFirmsModel = pharmaceuticals.Select(ModelFactory.Create).ToList<PharmaceuticalFirmModel>();
                    return PartialView("DisplayPartial", pharmaceuticalFirmsModel);

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