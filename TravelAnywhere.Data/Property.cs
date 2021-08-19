using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Data
{
   public class Property
    {
        [Key]
        public int PropertyID { get; set; }
        [Required]
        public string Properties { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Guid OwnerID { get; set; }

        [ForeignKey("Location")]
        public int? LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}
