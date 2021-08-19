using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Models
{
    public class RatingCreate
    {
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
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

