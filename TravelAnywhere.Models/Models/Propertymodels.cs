using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;

namespace TravelAnywhere.Models
{
    public class PropertyCreate
    {
        public int LocationID { get; set; }
        public string Locations { get; set; }
        public string Properties { get; set; }
        [Display(Name = "Price Per Night")]
        public decimal Price { get; set; }
    }
    public class PropertyDetail
    {
        public int PropertyID { get; set; }
        [Display(Name = "Address")]
        public string Properties { get; set; }
        [Display(Name = "Price Per Night")]
        public decimal Price { get; set; }
        public int LocationID { get; set; }
    }
    public class PropertyEdit
    {
        public int LocationID { get; set; }
        public int PropertyID { get; set; }
        [Display(Name ="Address")]
        public string Properties { get; set; }
        [Display(Name = "Price Per Night")]
        public decimal Price { get; set; }
    }
    public class PropertyListItem
    {
        public int PropertyID { get; set; }
        [Display(Name = "Address")]
        public string Properties { get; set; }
        [Display(Name ="Price Per Night")]
        public decimal Price { get; set; }
        public virtual Location Location { get; set; }
    }
    public class PropertyLocationList
    {
        public int PropertyID { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public List<ReviewListItem> Reviews { get; set; }
        public List<RatingListItem> Ratings { get; set; }
    }
}

