
using OutReachApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OutReachApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        OutReachAppDBContext db = new OutReachAppDBContext();
        public ActionResult Index()//Navigation page to Registration Page
        {
            if (Session["PkVolID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();

            }
         
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
                //var i = Convert.ToInt32(Id);
                
                bool success = Int32.TryParse(Id, out var i);
                if (success)
                {
                    var obj = db.Admins.Where(a => a.AdminId.Equals(i) && a.AdminPassword.Equals(password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["AdminID"] = obj.AdminId;
                        return this.RedirectToAction("AdminIndex", "Admin");
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Invalid User ID (or) Incorrect Password");
                    }
                }
                else
                {
                    ViewBag.Message= string.Format("Please give valid ID");
                }
                
                

            }
            else if (role == "Volunteer")
            {
                var obj = db.Volunteers.Where(a => a.VolunteerId.Equals(Id) && a.VolunteerPassword.Equals(password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["PkVolID"] = obj.PK_VolunteerId;

                    Session["VolID"] = obj.VolunteerId;

                    
                    
                    return this.RedirectToAction("Index", "Volunteer");
                }
                else
                {
                    ViewBag.Message = string.Format("Invalid User ID (or) Incorrect Password");
                }

            }

            return View();
        }

        public ActionResult Logout()
        {



            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            FormsAuthentication.SignOut();
            HttpContext.Session["AdminID"] = null;
            HttpContext.Session["PkVolID"] = null;
           
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            HttpContext.Session.Clear();
            Session.RemoveAll();
            HttpContext.Session.Abandon();
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Home");



        }

    }
}