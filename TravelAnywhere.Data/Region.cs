using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Data
{
   public class Region
    {
        [Key]
        public int RegionID { get; set; }

        public virtual  List<Location> Locations { get; set; }
        [Required]
        public string Regions { get; set; }
        public Guid OwnerID { get; set; }
    }
}
