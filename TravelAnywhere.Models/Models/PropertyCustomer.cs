using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;

namespace TravelAnywhere.Models.Models
{
    public class PropertyCustomer
    {
        public int PropertyID { get; set; }
        [Display(Name ="Address")]
        public string Properties { get; set; }
        [Display(Name = "Price Per Night")]
        public decimal Price { get; set; }
        public DateTime DatesAvailable { get; set; }
        public List<RatingListItem> Ratings { get; set; } = new List<RatingListItem>();
        public List<ReviewListItem> Reviews { get; set; } = new List<ReviewListItem>();
        // public string Locations { get; set; }
        /* public int AvgRating
         {
             get
             {

             }
         }*/
    }
}
