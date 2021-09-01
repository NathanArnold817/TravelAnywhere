using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Models
{
    public class LocationCreate
    {
        [Display(Name ="City, Country")]
        public string Locations { get; set; }
        public int RegionID { get; set; }
        public string Regions { get; set; }
    }
    public class LocationDetail
    {
        public int LocationID { get; set; }
        [Display(Name = "City, Country")]
        public string Locations { get; set; }
    }
    public class LocationEdit
    {
        public int LocationID { get; set; }
        public int RegionID { get; set; }
        [Display(Name = "City, Country")]
        public string Locations { get; set; }
    }
    public class LocationListItem
    {
        public int LocationID { get; set; }
        [Display(Name = "City, Country")]
        public string Locations { get; set; }
    }
}
