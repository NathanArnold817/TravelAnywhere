using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAnywhere.Data;

namespace TravelAnywhere.Models.Models
{
   public class Homepage
    {
        [Display(Name ="Where would you like to go?")]
        public string Locations { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
     /*   public virtual Review Review { get; set; }
        public virtual Rating Rating { get; set; }*/

    }
}
