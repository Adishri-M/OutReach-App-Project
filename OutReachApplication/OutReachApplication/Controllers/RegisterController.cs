using OutReachApplication.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OutReachApplication.Controllers
{
    public class RegisterController : Controller
    {
        OutReachAppDBContext db = new OutReachAppDBContext();
        // GET: Register
        public ActionResult Index()
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
        // GET: Volunteers/Create
        //volunteer Registration
        public ActionResult Create()
        {
            int count = (from row in db.Volunteers select row).Count();
            if (count > 0)
            {
                TempData["volid"] = "V_" + (count + 1);
            }
            else
            {
                TempData["volid"] = "V_1";
            }
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Volunteer volunteer)
        {
            string f_name = Request.Form["FirstName"];
            string l_name = Request.Form["LastName"];
            CultureInfo culture = new CultureInfo("en-US"); 
            DateTime dob = Convert.ToDateTime("1/1/2010 12:10:15 PM", culture);
            string gender = Request.Form["Gender"];
            string c_no = Request.Form["ContactNumber"];
            string v_id = Request.Form["VolunteerId"];
            string pwd = Request.Form["VolunteerPassword"];

            if (ModelState.IsValid)
            {
                Volunteer ob = new Volunteer();
                ob.FirstName = f_name;
                ob.LastName = l_name;
                ob.DOB = dob;
                ob.Gender = gender;
                ob.ContactNumber = c_no;
                ob.VolunteerId = v_id;
                ob.VolunteerPassword = pwd;
                ob.ConfirmPassword = pwd;

                db.Volunteers.Add(volunteer);
                db.SaveChanges();
                ViewBag.Message = String.Format("Registered Successfully with VolunteerId ={0}",v_id);

                //return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}