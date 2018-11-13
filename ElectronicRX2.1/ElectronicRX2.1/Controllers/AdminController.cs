using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicRX2._1.Controllers
{
    public class AdminController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            AdminSearchViewModel model = new AdminSearchViewModel();
            model.condition = "";
            model.value = "";
            model.user = "";            
            var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email" });
            ViewBag.SearchType = searchCategory;
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(AdminSearchViewModel search)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<AdminModel> admins = new List<AdminModel>();
                    
                    if (search.condition == "First Name")
                    {
                        var users = db.Users.Where(i => i.UserFirstName == search.value && i.UserType == "Admin");
                        foreach(ApplicationUser user in users)
                        {
                            if(user.UserName != User.Identity.Name)
                            {
                                admins.Add(user.GetAdmin());
                            }
                            
                        }
                        
                    }
                    else
                        if (search.condition == "Last Name")
                        {
                            var users = db.Users.Where(i => i.UserLastName == search.value && i.UserType == "Admin");
                            foreach (ApplicationUser user in users)
                            {
                                admins.Add(user.GetAdmin());
                            }
                        }
                        else
                        {
                            var users = db.Users.Where(i => i.Email == search.value && i.UserType == "Admin");
                            foreach (ApplicationUser user in users)
                            {
                                admins.Add(user.GetAdmin());
                            }
                        }
                    var searchCategory = new SelectList(new[] { "First Name", "Last Name", "Email" });
                    ViewBag.SearchType = searchCategory;
                    return PartialView("_AdminTablePartial", admins);
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


        public ActionResult New()
        {
            return View();
        }

        //POST: Admin/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a user for this
                    var idManager = new IdentityManager();
                    var user = adminModel.GetUser();
                    var result = idManager.CreateUser(user, adminModel.Password);
                    if (result)
                    {
                        idManager.AddUserToRole(adminModel.Email, user.UserType);                        
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
                    return View(adminModel);
                }
            }
            return View(adminModel);
        }
    }
}