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
    public class RatingController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            var model = service.GetRating();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRatingService();

            if (service.CreateRating(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingById(id);
            var model =
                new RatingEdit
                {
                    RatingID = detail.RatingID,
                    Ratings = detail.Ratings
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RatingID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRatingService();

            if (service.UpdateRating(model))
            {
                TempData["SaveResult"] = "The Region was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Region could not be updated.");
            return View(model);
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRating(int id)
        {
            var service = CreateRatingService();
            service.DeleteRating(id);
            TempData["SaveResult"] = "Your note was deleted.";
            return RedirectToAction("Index");
        }
    }
}