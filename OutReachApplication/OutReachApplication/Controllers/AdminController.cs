using OutReachApplication.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OutReachApplication.Controllers
{
    public class AdminController : Controller
    {
        OutReachAppDBContext db = new OutReachAppDBContext();
        // GET: Admin
        public ActionResult Index()
        {

            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();

            }

        }
        public ActionResult AdminIndex()
        {

            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();

            }

        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(EventDetail eventdetail)
        {

            string activity = Request.Form["Activity"];
            string eventtype = Request.Form["Event Type"];
            string description = Request.Form["Description"];
            CultureInfo culture = new CultureInfo("en-US");
            DateTime dob = Convert.ToDateTime("1/1/2010 12:10:15 PM", culture);
            string place = Request.Form["Place"];
            string c_no = Request.Form["ContactNumber"];
            string no_vol = Request.Form["NoOfVolunteers"];



            if (ModelState.IsValid)

            {
                EventDetail ob = new EventDetail();
                ob.Activity = activity;
                ob.EventType = eventtype;
                ob.Description = description;
                ob.Date = dob;
                ob.Place = place;
                ob.ContactNumber = c_no;
                ob.NoOfVolunteers = Convert.ToInt32(no_vol);
               
                db.EventDetails.Add(eventdetail);
                db.SaveChanges();


                ViewBag.Message = String.Format("Event Added Successfully");

            }
            return View();

        }
        public ActionResult VolunteerListByLocation()
        {

            var location = (from s in db.Attendances select s.Place).Distinct().ToList();
            ViewBag.ByLocation = location;
            return View();
        }
        [HttpPost]
        public ActionResult VolunteerListByLocation(Attendance attendance)
        {
            var location = attendance.Place;
            return RedirectToAction("ViewByLocation", "Admin", new { LocationName = location });

        }

        public ActionResult ViewByLocation(string LocationName)
        {
            var loc = db.Attendances.Where(x => x.Place == LocationName).ToList();
            return View(loc);
        }

        public ActionResult VolunteerListByActivity()
        {

            var eventname = (from s in db.Attendances select s.EventName).Distinct().ToList();
            ViewBag.ByEventName= eventname;
            return View();
        }
        [HttpPost]
        public ActionResult VolunteerListByActivity(Attendance attendance)
        {
            var eventname = attendance.EventName;
            return RedirectToAction("ViewByActivity", "Admin", new { ActivityName = eventname });

        }

        public ActionResult ViewByActivity(string ActivityName)
        {
            var eve = db.Attendances.Where(x => x.EventName == ActivityName).ToList();
            return View(eve);
        }

        public ActionResult VolunteerListByMonth()
        {
            DateTime today = DateTime.Today;
            var result = from t in db.Attendances
                         where (t.DOE.Month == today.Month) && (t.DOE.Year == today.Year)
                         select t;
            return View(result.ToList());
        }

        public ActionResult ViewFeedback()
        {
            var feedback =db.Feedbacks.ToList();
            return View(feedback);
        }



    }
}