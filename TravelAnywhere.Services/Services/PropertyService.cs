using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;
using TravelAnywhere.Models;

namespace TravelAnywhere.Services
{
   public class PropertyService
    {
        private readonly Guid _userId;

        public PropertyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProperty(PropertyCreate model)
        {
            var entity =
                new Property()
                {
                    OwnerID = _userId,
                    Properties = model.Properties,
                    LocationID = model.LocationID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Properties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PropertyListItem> GetProperty()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Properties
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new PropertyListItem
                        {
                            PropertyID = e.PropertyID,
                            Properties = e.Properties
                        });
                return query.ToArray();
            }
        }

        public PropertyDetail GetPropertyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Properties
                    .Single(e => e.PropertyID == id && e.OwnerID == _userId);
                return
                        new PropertyDetail
                        {
                            PropertyID = entity.PropertyID,
                            Properties = entity.Properties
                        };
            }
        }

        public bool UpdateProperty(PropertyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Properties
                    .Single(e => e.PropertyID == model.PropertyID && e.OwnerID == _userId);

                entity.PropertyID = model.PropertyID;
                entity.Properties = model.Properties;
                entity.LocationID = model.LocationID;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProperty(int PropertyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Properties
                    .Single(e => e.PropertyID == PropertyID && e.OwnerID == _userId);

                ctx.Properties.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
