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
    public class PharmacyController : Controller
    {

        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();
        

        // GET: Pharmacy
        public ActionResult Index()
        {
            PharmacySearchViewModel model = new PharmacySearchViewModel();
            model.condition = "";
            model.value = "";
            var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
            ViewBag.SearchType = searchCategory;
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(PharmacySearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Pharmacy> pharmacies = new List<Pharmacy>();

                    if (search.condition == "Name")
                    {
                        pharmacies = PrescriptionService.pharmacies.GetAllUsingName(search.value);                       

                    }
                    else
                        if (search.condition == "State")
                        {
                            pharmacies = PrescriptionService.pharmacies.GetAllUsingStateName(search.value);

                        }
                        else
                        {
                            pharmacies = PrescriptionService.pharmacies.GetAllUsingZipCode(search.value);
                        }

                    List<PharmacyModel> model = pharmacies.Select(ModelFactory.Create).ToList<PharmacyModel>();
                    var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
                    ViewBag.SearchType = searchCategory;
                    return PartialView("_PharmacyTablePartial", model);
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

        [HttpGet]
        [ChildActionOnly]
        public ActionResult SearchPartial()
        {
            PharmacySearchViewModel s = new PharmacySearchViewModel();
            s.condition = "";
            s.value = "";

            var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
            ViewBag.SearchType = searchCategory;
            return PartialView("_SearchPartial", s);
        }

        [HttpPost]
        public PartialViewResult SearchPartial(PharmacySearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Pharmacy> pharmacies = new List<Pharmacy>();

                    if (search.condition == "Name")
                    {
                        pharmacies = PrescriptionService.pharmacies.GetAllUsingName(search.value);
                        

                    }
                    else
                        if (search.condition == "State")
                        {
                            pharmacies = PrescriptionService.pharmacies.GetAllUsingStateName(search.value);                            
                        }
                        else
                        {
                            pharmacies = PrescriptionService.pharmacies.GetAllUsingZipCode(search.value);
                        }

                    List<PharmacyModel> model = pharmacies.Select(ModelFactory.Create).ToList<PharmacyModel>();
                    var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
                    ViewBag.SearchType = searchCategory;
                    return PartialView("_PharmacyTableSelect", model);
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
    }
}