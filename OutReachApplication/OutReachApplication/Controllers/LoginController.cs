
using OutReachApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OutReachApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        OutReachAppDBContext db = new OutReachAppDBContext();
        public ActionResult Index()//Navigation page to Registration Page
        {
            return View();
        }
       

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Volunteer volunteer)
        {

            string role = Request.Form["role"];
            string Id = Request.Form["Id"];
            string password = Request.Form["Password"];

            if (role == "")
            {
                ViewBag.Message = string.Format("Please Select Role");
            }
            else if (Id == "")
            {
                ViewBag.Message = string.Format("ID Should Not be Empty");
            }
            else if (password == "")
            {
                ViewBag.Message = string.Format("password Should Not be Empty");
            }
            else
            if (role == "Admin")
            {
                var i = Convert.ToInt32(Id);
                var obj = db.Admins.Where(a => a.AdminId.Equals(i) && a.AdminPassword.Equals(password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["AdminID"] = obj.AdminId;
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = string.Format("Invalid User ID (or) Incorrect Password");
                }

            }
            else if (role == "Volunteer")
            {
                var obj = db.Volunteers.Where(a => a.VolunteerId.Equals(Id) && a.VolunteerPassword.Equals(password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["PkVolID"] = obj.PK_VolunteerId;

                    Session["VolID"] = obj.VolunteerId;


                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = string.Format("Invalid User ID (or) Incorrect Password");
                }

            }

            return View();
        }
    }
}