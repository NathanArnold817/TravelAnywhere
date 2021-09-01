using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;
using TravelAnywhere.Models;
using TravelAnywhere.Models.Models;

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
                    DatesAvailable = DateTime.Now,
                    LocationID=model.LocationID,
                    OwnerID = _userId,
                    Properties = model.Properties,
                    Price = model.Price

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
                            Properties = e.Properties,
                            Price = e.Price,
                            Location = e.Location
                        });
                return query.ToArray();
            }
        }
        public IEnumerable<PropertyCustomer>ViewProperties()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Properties
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new PropertyCustomer
                        {
                            PropertyID = e.PropertyID,
                            Properties = e.Properties,
                            Price = e.Price
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
                            LocationID = entity.LocationID,
                            PropertyID = entity.PropertyID,
                            Properties = entity.Properties,
                            Price = entity.Price,
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
                entity.LocationID = model.LocationID;
                entity.PropertyID = model.PropertyID;
                entity.Properties = model.Properties;
                entity.Price = model.Price;

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
