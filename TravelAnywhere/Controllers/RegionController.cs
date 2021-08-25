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
    public class RegionController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RegionService(userId);
            var model = service.GetRegion();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRegionService();

            if (service.CreateRegion(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRegionService();
            var model = svc.GetRegionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRegionService();
            var detail = service.GetRegionById(id);
            var model =
                new RegionEdit
                {
                    RegionID = detail.RegionID,
                    Regions = detail.Regions
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RegionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RegionID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRegionService();

            if (service.UpdateRegion(model))
            {
                TempData["SaveResult"] = "The Region was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Region could not be updated.");
            return View(model);
        }

        private RegionService CreateRegionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RegionService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRegionService();
            var model = svc.GetRegionById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRegion(int id)
        {
            var service = CreateRegionService();
            service.DeleteRegion(id);
            TempData["SaveResult"] = "Your Region was deleted.";
            return RedirectToAction("Index");
        }
    }
}