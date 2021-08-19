using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;
using TravelAnywhere.Models;

namespace TravelAnywhere.Services
{
   public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    OwnerID = _userId,
                    Locations = model.Locations,
                    RegionID = model.RegionID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocation()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new LocationListItem
                        {
                            LocationID = e.LocationID,
                            Locations = e.Locations
                        });
                return query.ToArray();
            }
        }

        public LocationDetail GetPropertyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationID == id && e.OwnerID == _userId);
                return
                        new LocationDetail
                        {
                            LocationID = entity.LocationID,
                            Locations = entity.Locations
                        };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationID == model.LocationID && e.OwnerID == _userId);

                entity.RegionID = model.RegionID;
                entity.Locations = model.Locations;
                entity.LocationID = model.LocationID;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLocation(int LocationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationID == LocationID && e.OwnerID == _userId);

                ctx.Locations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
