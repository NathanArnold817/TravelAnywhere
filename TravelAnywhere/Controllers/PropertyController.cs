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
    public class PropertyController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            var model = service.GetProperty();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePropertyService();

            if (service.CreateProperty(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePropertyService();
            var detail = service.GetPropertyById(id);
            var model =
                new PropertyEdit
                {
                    PropertyID = detail.PropertyID,
                    Properties = detail.Properties
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PropertyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePropertyService();

            if (service.UpdateProperty(model))
            {
                TempData["SaveResult"] = "The Region was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Region could not be updated.");
            return View(model);
        }

        private PropertyService CreatePropertyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProperty(int id)
        {
            var service = CreatePropertyService();
            service.DeleteProperty(id);
            TempData["SaveResult"] = "Your note was deleted.";
            return RedirectToAction("Index");
        }
    }
}