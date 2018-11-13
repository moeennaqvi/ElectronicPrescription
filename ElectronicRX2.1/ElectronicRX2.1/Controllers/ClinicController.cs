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
    public class ClinicController : Controller
    {
        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();
       
        // GET: Clinic
        public ActionResult Index()
        {
            ClinicSearchViewModel model = new ClinicSearchViewModel();
            model.condition = "";
            model.value = "";
            var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
            ViewBag.SearchType = searchCategory;
            return View(model);            
        }

        [HttpPost]
        public PartialViewResult Search(ClinicSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Clinic> clinics = new List<Clinic>();

                    if (search.condition == "Name")
                    {
                        clinics = PrescriptionService.clinics.GetAllUsingName(search.value);

                    }
                    else
                        if (search.condition == "State")
                        {
                            clinics = PrescriptionService.clinics.GetAllUsingState(search.value);
                        }
                        else
                        {
                            clinics = PrescriptionService.clinics.GetAllUsingZipCode(search.value);
                        }

                    List<ClinicModel> model = clinics.Select(ModelFactory.Create).ToList<ClinicModel>();
                    var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
                    ViewBag.SearchType = searchCategory;
                    return PartialView("_ClinicTablePartial", model);
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
            ClinicSearchViewModel s = new ClinicSearchViewModel();
            s.condition = "";
            s.value = "";
            
            var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
            ViewBag.SearchType = searchCategory;
            return PartialView("_SearchPartial", s);
        }

        [HttpPost]
        public PartialViewResult SearchPartial(ClinicSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Clinic> clinics = new List<Clinic>();

                    if (search.condition == "Name")
                    {
                        clinics = PrescriptionService.clinics.GetAllUsingName(search.value);

                    }
                    else
                        if (search.condition == "State")
                        {
                            clinics = PrescriptionService.clinics.GetAllUsingState(search.value);
                        }
                        else
                        {
                            clinics = PrescriptionService.clinics.GetAllUsingZipCode(search.value);
                        }

                    List<ClinicModel> model = clinics.Select(ModelFactory.Create).ToList<ClinicModel>();
                    var searchCategory = new SelectList(new[] { "Name", "State", "Zip Code" });
                    ViewBag.SearchType = searchCategory;
                    return PartialView("_ClinicTableSelect", model);
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