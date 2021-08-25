using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;
using TravelAnywhere.Models;

namespace TravelAnywhere.Services
{
    public class RegionService
    {
        private readonly Guid _userId;

        public RegionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRegion(RegionCreate model)
        {
            var entity =
                new Region()
                {
                    OwnerID = _userId,
                    Regions = model.Regions,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Regions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RegionListItem> GetRegion()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Regions
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new RegionListItem
                        {
                            RegionID = e.RegionID,
                            Regions = e.Regions
                        });
                return query.ToArray();
            }
        }

        public RegionDetail GetRegionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Regions
                    .Single(e => e.RegionID == id && e.OwnerID == _userId);
                return
                        new RegionDetail
                        {
                            RegionID = entity.RegionID,
                            Regions = entity.Regions
                        };
            }
        }

        public bool UpdateRegion(RegionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Regions
                    .Single(e => e.RegionID == model.RegionID && e.OwnerID == _userId);

                entity.Regions = model.Regions;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRegion(int RegionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Regions
                    .Single(e => e.RegionID == RegionID && e.OwnerID == _userId);

                ctx.Regions.Remove(entity);
                return ctx.SaveChanges() ==1;
            }
        }
    }
}
