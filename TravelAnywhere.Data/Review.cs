using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Data
{
   public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public string Reviews { get; set; }
        public Guid OwnerID { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey("Property")]
        public int? PropertyID { get; set; }
        public virtual Property Property { get; set; }

        [ForeignKey("Location")]
        public int? LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}
