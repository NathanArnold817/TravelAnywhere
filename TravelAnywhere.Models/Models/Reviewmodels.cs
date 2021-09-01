using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;

namespace TravelAnywhere.Models
{
    public class ReviewCreate
    {
        public int? LocationID { get; set; }
        public int? PropertyID { get; set; }
        public string Reviews { get; set; }
    }
    public class ReviewDetail
    {
        public virtual Property Property { get; set; }
        public virtual Location Location { get; set; }
        public int ReviewID { get; set; }
        public string Reviews { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
    public class ReviewEdit
    {
        public int ReviewID { get; set; }
        public string Reviews { get; set; }
    }
    public class ReviewListItem
    {
        public int ReviewID { get; set; }
        public string Reviews { get; set; }
        public virtual Property Property { get; set; }
        public virtual Location Location { get; set; }
    }
}


