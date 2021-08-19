using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Models
{
    public class LocationCreate
    {
        public string Locations { get; set; }
        public int RegionID { get; set; }
    }
    public class LocationDetail
    {
        public int LocationID { get; set; }
        public string Locations { get; set; }
    }
    public class LocationEdit
    {
        public int LocationID { get; set; }
        public int RegionID { get; set; }
        public string Locations { get; set; }
    }
    public class LocationListItem
    {
        public int LocationID { get; set; }
        public string Locations { get; set; }
    }
}
