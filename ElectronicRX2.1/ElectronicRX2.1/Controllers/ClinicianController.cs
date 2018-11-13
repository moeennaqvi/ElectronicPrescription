using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectronicRX2._1.Models;
using Microsoft.AspNet.Identity;
using ElectronicRX2._1.DataAccess;
using ElectronicRX2._1.DataAccess.Entities;

namespace ElectronicRX2._1.Controllers
{
    public class ClinicianController : Controller
    {
        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();
        

        // GET: Clinician
        public ActionResult Index()
        {
            ClinicianSearchViewModel model = new ClinicianSearchViewModel();
            model.condition = "";
            model.value = "";
            var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email", "Clinic Name" });
            ViewBag.SearchType = searchCategory;
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(ClinicianSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Clinician> clinicians;
                    if (search.condition == "First Name")
                    {
                        clinicians = PrescriptionService.clinicians.GetAllUsingFirstName(search.value);
                    }
                    else
                        if (search.condition == "Last Name")
                        {
                            clinicians = PrescriptionService.clinicians.GetAllUsingLastName(search.value);
                        }
                        else
                            if(search.condition == "Email")
                        {
                            clinicians = PrescriptionService.clinicians.GetAllUsingEmail(search.value);

                        }
                            else
                            {
                                clinicians = PrescriptionService.clinicians.GetAllUsingClinicName(search.value);
                            }
                    var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email", "Clinic Name" });
                    ViewBag.SearchType = searchCategory;

                    List<ClinicianModel> model = clinicians.Select(ModelFactory.Create).ToList<ClinicianModel>();
                    return PartialView("_ClinicianTablePartial", model);
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

        // GET: Clinician/Details/5
        public ActionResult Details(string id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorModel clinicians = db.PhysicianUsers.Find(id);
            if (clinicians == null)
            {
                return HttpNotFound();
            }
            return View(clinicians);
             */
            return View();
        }

        // GET: Clinician/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneNumber,FaxNumber,StreetAddress,City,State,ZipCode,ID,FirstName,LastName,Gender,DOB,MobileNumber,ClinicName,Password,ConfirmPassword")] DoctorModel clinicianModels)
        {
            if (ModelState.IsValid)
            {
                /*
                var idManager = new IdentityManager();
                var user = clinicianModels.GetUser();
                var result = idManager.CreateUser(user, clinicianModels.Password);
                if (result)
                {
                    idManager.AddUserToRole(clinicianModels.ID, "Physician");
                    db.PhysicianUsers.Add(clinicianModels);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
                */
            }

            return View(clinicianModels);
        }

        // GET: Clinician/Edit/5
        public ActionResult Edit(string id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorModel clinicianModels = db.PhysicianUsers.Find(id);
            if (clinicianModels == null)
            {
                return HttpNotFound();
            }
            return View(clinicianModels);
             */
            return View();
        }

        // POST: Clinician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneNumber,FaxNumber,StreetAddress,City,State,ZipCode,ID,FirstName,LastName,Gender,DOB,MobileNumber,ClinicName,Password,ConfirmPassword")] DoctorModel clinicianModels)
        {
            if (ModelState.IsValid)
            {

                var user = clinicianModels.GetUser();
                if (user == null)
                {
                    return HttpNotFound();
                }
                try
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(clinicianModels).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
                /*
                var idManager = new IdentityManager();
                var user = clinicianModels.GetUser();
                var result = idManager.UpdateUser(user);
                if(result)
                {
                    db.Entry(clinicianModels).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
               
            }
            return View(clinicianModels);
        }
        */
        // GET: Clinician/Delete/5
        public ActionResult Delete(string id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorModel clinicianModels = db.PhysicianUsers.Find(id);
            if (clinicianModels == null)
            {
                return HttpNotFound();
            }
            return View(clinicianModels);
             */
            return View();
        }

        // POST: Clinician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            /*
            DoctorModel clinicianModels = db.PhysicianUsers.Find(id);
            if (clinicianModels == null)
            {
                return HttpNotFound();
            }
            var user = db.Users.First(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            try
            {
                db.Users.Remove(user);
                db.PhysicianUsers.Remove(clinicianModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            /*
            var idManager = new IdentityManager();            
            Clinician clinicianModels = db.PhysicianUsers.Find(id);
            var user = clinicianModels.GetUser();
            var result = idManager.DeleteUser(user);
            if(result)
            {
                db.PhysicianUsers.Remove(clinicianModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
            */
            return View();
        }
        
        
    }
}
