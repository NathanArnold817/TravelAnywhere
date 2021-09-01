using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;

namespace TravelAnywhere.Models
{
    public class RatingCreate
    {
        public string Locations { get; set; }
        public string Properties { get; set; }
        public int? LocationID { get; set; }
        public int? PropertyID { get; set; }
        public int Ratings { get; set; }
    }
    public class RatingDetail
    {
        public int RatingID { get; set; }
        public int Ratings { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
    public class RatingEdit
    {
        public int RatingID { get; set; }
        public int Ratings { get; set; }
    }
    public class RatingListItem
    {
        public int RatingID { get; set; }
        public int Ratings { get; set; }
        public virtual Property Property { get; set; }
        public virtual Location Location { get; set; }

        /*  [Display(Name ="Created")]
          public DateTimeOffset CreatedUtc { get; set; }*/
    }
}

