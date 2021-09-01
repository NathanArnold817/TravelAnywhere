using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;
using TravelAnywhere.Models;

namespace TravelAnywhere.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    OwnerID = _userId,
                    Reviews = model.Reviews
                    //LocationID = model.LocationID,    not sure if need
                    //PropertyID = model.PropertyID     do i need this?
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReview()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new ReviewListItem
                        {
                            ReviewID = e.ReviewID,
                            Reviews = e.Reviews,
                            Location = e.Location,
                            Property = e.Property
                        });
                return query.ToArray();
            }
        }
      
        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == id && e.OwnerID == _userId);
                return
                        new ReviewDetail
                        {
                           
                            ReviewID = entity.ReviewID,
                            Reviews = entity.Reviews,
                            CreatedUtc = entity.CreatedUtc,
                            ModifiedUtc = entity.ModifiedUtc
                        };
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == model.ReviewID && e.OwnerID == _userId);

                entity.ReviewID = model.ReviewID;
                entity.Reviews = model.Reviews;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReview(int ReviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == ReviewID && e.OwnerID == _userId);

                ctx.Reviews.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
