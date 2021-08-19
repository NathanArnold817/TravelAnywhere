using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;
using TravelAnywhere.Models;

namespace TravelAnywhere.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new Rating()
                {
                    OwnerID = _userId,
                    Ratings = model.Ratings,
                    //LocationID = model.LocationID,    not sure if need
                    //PropertyID = model.PropertyID     do i need this?
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRating()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new RatingListItem
                        {
                            Ratings = e.Ratings
                        });
                return query.ToArray();
            }
        }

        public RatingDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.RatingID == id && e.OwnerID == _userId);
                return
                        new RatingDetail
                        {
                            RatingID = entity.RatingID,
                            Ratings = entity.Ratings,
                            CreatedUtc = entity.CreatedUtc,
                            ModifiedUtc = entity.ModifiedUtc
                        };
            }
        }

        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.RatingID == model.RatingID && e.OwnerID == _userId);

                entity.RatingID = model.RatingID;
                entity.Ratings = model.Ratings;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRating(int RatingID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.RatingID == RatingID && e.OwnerID == _userId);

                ctx.Ratings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
