using AjaxDemo.Models;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [HttpGet]
        public JsonResult GetTrips()
        {
            SQLOperation s = new SQLOperation();
            //List<TripVM> trips = new List<TripVM>();
            //var trlist = s.GetTrips();
            //foreach (trip vm in trlist)
            //{
            //    trips.Add(new TripVM
            //    {
            //        TripID = vm.TripID,
            //        Description = vm.Description,
            //        Destination = vm.Destination,
            //        StartDate = Convert.ToString(vm.StartDate),
            //        EndDate = Convert.ToString(vm.EndDate)
            //    });
            //}

            List<trip> trips = s.GetTrips();
            return Json(trips, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTrip(int TripID)
        {
            //TripService tr = new TripService();
            SQLOperation s = new SQLOperation();
            var result = s.DeleteTripRepo(TripID);
            if (result)
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}