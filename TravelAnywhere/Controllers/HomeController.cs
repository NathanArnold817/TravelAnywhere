using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAnywhere.Models.Models;
using TravelAnywhere.Services;

namespace TravelAnywhere.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PropertyCustomer(List<PropertyCustomer> Locations)
        {
           
            return View(Locations);
        }
        [HttpPost]
        public ActionResult Index(Homepage views)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationByString(views);
          
           return View("PropertyCustomer", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }
    }
}