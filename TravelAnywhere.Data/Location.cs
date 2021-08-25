using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Data
{
   public class Location
    {
        public int LocationID { get; set; }
        [Required]
        public string Locations { get; set; }
        public Guid OwnerID { get; set; }

        [ForeignKey("Region")]
        public int? RegionID { get; set; }
        public string Regions { get; set; }
        public virtual Region Region { get; set; }
    }
}
