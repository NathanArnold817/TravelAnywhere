using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Data
{
   public class Rating
    {
        [Key]
        public int RatingID { get; set; }
        [Required]
        public int Ratings { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey("Property")]
        //public string Properties { get; set; }
        public int? PropertyID { get; set; }
        public virtual Property Property { get; set; }

        [ForeignKey("Location")]
       // public string Locations { get; set; }
        public int? LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}
