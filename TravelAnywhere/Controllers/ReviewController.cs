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
    public class ReviewController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GetReview();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReviewService();

            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewById(id);
            var model =
                new ReviewEdit
                {
                    ReviewID = detail.ReviewID,
                    Reviews = detail.Reviews
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReviewID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateReviewService();

            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "The Region was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Region could not be updated.");
            return View(model);
        }

        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReview(int id)
        {
            var service = CreateReviewService();
            service.DeleteReview(id);
            TempData["SaveResult"] = "Your note was deleted.";
            return RedirectToAction("Index");
        }
    }
}