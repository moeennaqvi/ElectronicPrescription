using ElectronicRX2._1.DataAccess;
using ElectronicRX2._1.DataAccess.Entities;
using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ElectronicRX2._1.Controllers
{
    public class PharmacistController : Controller
    {
        public IPrescriptionService PrescriptionService = new PrescriptionService();
        public IModelFactory ModelFactory = new ModelFactory();
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Pharmacist
        public ActionResult Index()
        
        
        {
            PharmacistSearchViewModel model = new PharmacistSearchViewModel();
            model.condition = "";
            model.value = "";
            var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email", "Pharmacy Name" });
            ViewBag.SearchType = searchCategory;
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(PharmacistSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Pharmacist> pharmacists;
                    if (search.condition == "First Name")
                    {
                        pharmacists = PrescriptionService.pharmacists.GetAllUsingFirstName(search.value);
                    }
                    else
                        if (search.condition == "Last Name")
                        {
                            pharmacists = PrescriptionService.pharmacists.GetAllUsingLastName(search.value);
                            
                        }
                        else
                            if (search.condition == "Email")
                            {
                                pharmacists = PrescriptionService.pharmacists.GetAllUsingEmail(search.value);

                            }
                            else
                            {
                                pharmacists = PrescriptionService.pharmacists.GetAllUsingPharmacyName(search.value);
                            }
                    var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email", "Pharmacy Name" });
                    ViewBag.SearchType = searchCategory;

                    List<PharmacistModel> model = pharmacists.Select(ModelFactory.Create).ToList<PharmacistModel>();
                    return PartialView("_PharmacistTablePartial", model);
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

        // GET: Pharmacist/Details/5
        public ActionResult Details(string id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PharmacyUserModel pharmacists = db.PharmacyUsers.Find(id);
            if (pharmacists == null)
            {
                return HttpNotFound();
            }
            return View(pharmacists); */
            return View();
        }

        // GET: Pharmacist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneNumber,FaxNumber,StreetAddress,City,State,ZipCode,ID,FirstName,LastName,Gender,DOB,MobileNumber,PharmacyName,Password,ConfirmPassword")] PharmacyUserModel pharmacistModels)
        {
            if (ModelState.IsValid)
            {
                /*
                db.PharmacyUsers.Add(pharmacistModels);
                db.SaveChanges();

                var idManager = new IdentityManager();
                try
                {
                    var user = pharmacistModels.GetUser();
                    var result = idManager.CreateUser(user, pharmacistModels.Password);
                    if (result)
                    {
                        idManager.AddUserToRole(pharmacistModels.ID, "PharmacyUser");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
                 */ 
            }

            return View(pharmacistModels);
        }

        // GET: Pharmacist/Edit/5
        public ActionResult Edit(string id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PharmacyUserModel pharmacistModels = db.PharmacyUsers.Find(id);
            if (pharmacistModels == null)
            {
                return HttpNotFound();
            }
            return View(pharmacistModels);
             */
            return View();
        }

        // POST: Pharmacist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneNumber,FaxNumber,StreetAddress,City,State,ZipCode,ID,FirstName,LastName,Gender,DOB,MobileNumber,PharmacyName,Password,ConfirmPassword")] PharmacyUserModel pharmacistModels)
        {
            if (ModelState.IsValid)
            {
                var user = pharmacistModels.GetUser();
                if (user == null)
                {
                    return HttpNotFound();
                }
                try
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(pharmacistModels).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("Error");
                }

                /*
                var result = idManager.UpdateUser(user);
                if (result)
                {
                    db.Entry(pharmacistModels).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
                */
            }
            return View(pharmacistModels);
        }

        // GET: Pharmacist/Delete/5
        public ActionResult Delete(string id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PharmacyUserModel pharmacistModels = db.PharmacyUsers.Find(id);
            if (pharmacistModels == null)
            {
                return HttpNotFound();
            }
            return View(pharmacistModels);
             */
            return View();
        }

        // POST: Pharmacist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            /*
            PharmacyUserModel pharmacistModels = db.PharmacyUsers.Find(id);
            if(pharmacistModels == null)
            {
                return HttpNotFound();
            }
            var user = db.Users.First(u => u.Id == id);
            if(user == null)
            {
                return HttpNotFound();
            }
            try
            {
                db.Users.Remove(user);
                db.PharmacyUsers.Remove(pharmacistModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
            /*
            return RedirectToAction("Index");
            var user = pharmacistModels.GetUser();
            var result = idManager.DeleteUser(user);
            if (result)
            {
                db.PharmacyUsers.Remove(pharmacistModels);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}