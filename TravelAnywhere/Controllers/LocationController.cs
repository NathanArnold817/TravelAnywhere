using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAnywhere.Models;
using TravelAnywhere.Services;

namespace TravelAnywhere.Controllers
{
    public class LocationController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            var model = service.GetLocation();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetPropertyById(id);
            var model =
                new LocationEdit
                {
                    LocationID = detail.LocationID,
                    Locations = detail.Locations
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LocationID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateLocationService();

            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "The Region was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Region could not be updated.");
            return View(model);
        }

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLocation(int id)
        {
            var service = CreateLocationService();
            service.DeleteLocation(id);
            TempData["SaveResult"] = "Your note was deleted.";
            return RedirectToAction("Index");
        }
    }
}