using OutReachApplication.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OutReachApplication.Controllers
{
    public class VolunteerController : Controller
    {
        OutReachAppDBContext db = new OutReachAppDBContext();
       
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

        // GET: Volunteer
        public ActionResult EventIndex()
        {
            var today = DateTime.Now;
            var dateFifteen = DateTime.Today.AddDays(15);

            var values = from e in db.EventDetails
                         where (e.Date >= today) && (e.Date <= dateFifteen) 
                         select e;
            return View(values.ToList());
        }

        //GET:Location
        public ActionResult SearchByLocation()
        {
            //ViewBag.ByLocation = new SelectList(db.EventDetails, "EventId", "Place");
            var location = (from s in db.EventDetails select s.Place).Distinct().ToList();
            ViewBag.ByLocation = location;
            return View();
        }

        [HttpPost]
        public ActionResult SearchByLocation(EventDetail eventDetail)
        {
            var location = eventDetail.Place;
            return RedirectToAction("DisplayByLocation", "Volunteer", new { LocationName = location });
            
        }

        public ActionResult DisplayByLocation(string LocationName)
        {
            var loc = db.EventDetails.Where(x => x.Place == LocationName).ToList();
            return View(loc);
        }
        //GET: EventType
        public ActionResult SearchByEventType()
        {
            //ViewBag.ByLocation = new SelectList(db.EventDetails, "EventId", "Place");
            var eventtype = (from s in db.EventDetails select s.EventType).Distinct().ToList();
            ViewBag.ByEventType = eventtype;
            return View();
        }

        [HttpPost]
        public ActionResult SearchByEventType(EventDetail eventDetail)
        {
            var eventtype = eventDetail.EventType;
            return RedirectToAction("DisplayByEventType", "Volunteer", new { EventTypeName = eventtype });

        }
        public ActionResult DisplayByEventType(string EventTypeName)
        {
            var eve = db.EventDetails.Where(x => x.EventType == EventTypeName).ToList();
            return View(eve);
        }


        public ActionResult JoinEvent(string activity)
        {
            ViewBag.Message = String.Format("Please Read Dos and Donts");
            var values = db.EventDetails.Where(x => x.Activity == activity).FirstOrDefault();
            return View(values);
            
        }

        
        public ActionResult VolunteerAttendance ()
        {
           var data = (from p in db.EventDetails select p.Activity).Distinct();
          
            SelectList list = new SelectList(data);
            ViewBag.Events = list;

            var data1 = (from p in db.EventDetails select p.Place).Distinct();
            SelectList list1 = new SelectList(data1);
            ViewBag.Places = list1;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VolunteerAttendance(Attendance attendance)
        {
            
            var data = (from p in db.EventDetails select p.Activity).Distinct();
            SelectList list = new SelectList(data);
            ViewBag.Events = list;

            var data1 = (from p in db.EventDetails select p.Place).Distinct();
            SelectList list1 = new SelectList(data1);
            ViewBag.Places = list1;

            string name = Request.Form["Name"];
            string id = Request.Form["VolunteerId"];
            string eventname = Request.Form["EventName"];
            CultureInfo culture = new CultureInfo("en-US");
            DateTime doe = Convert.ToDateTime("1/1/2010 12:10:15 PM", culture);
            string place = Request.Form["Place"];
            string attended = Request.Form["Attended"];
            

            if (ModelState.IsValid)
            {
                Attendance at = new Attendance();
                at.Name = name;
                at.VolunteerId = id;
                at.EventName = eventname;
                at.DOE = doe;
                at.Place = place;
                at.Attended = attended;


                db.Attendances.Add(attendance);
                db.SaveChanges();
                ViewBag.Message = String.Format("Attendance Submitted Successfully");

            }
            return View();
        }

        public ActionResult VolunteerFeedback()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VolunteerFeedback(Feedback feedback)
        {
            string id = Request.Form["VolunteerId"];
            string firstname = Request.Form["First Name"];
            string lastname = Request.Form["Last Name"];
            string question1 = Request.Form["Are_you_satisfied_for_this_Event"];
            string question2 = Request.Form["Have_you_faced_any_difficulties_in_this_Event"];
            string question3 = Request.Form["Do_you_think_the_duration_of_the_event_was_good_enough_as_per_your_expectation"];
            string question4 = Request.Form["Did_the_event_content_and_delivery_meet_your_expectation"];
            string question5 = Request.Form["Do_you_like_to_recommand_this_event_to_someone"];


            if (ModelState.IsValid)
            {
                Feedback fd = new Feedback();
                fd.VolunteerId = id;
                fd.FirstName = firstname;
                fd.LastName = lastname;
                fd.Are_you_satisfied_for_this_Event = question1;
                fd.Have_you_faced_any_difficulties_in_this_Event = question2;
                fd.Do_you_think_the_duration_of_the_event_was_good_enough_as_per_your_expectation = question3;
                fd.Did_the_event_content_and_delivery_meet_your_expectation = question4;
                fd.Do_you_like_to_recommand_this_event_to_someone = question5;

                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                ViewBag.Message = String.Format("Feedback Submitted Successfully");

            }
            return View();
        }


      





    }
}