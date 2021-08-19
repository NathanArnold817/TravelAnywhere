using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Models
{
   public class RegionCreate
    {
        public string Regions { get; set; }
    }
   public class RegionDetail
    {
        public int RegionID { get; set; }
        public string Regions { get; set; }
    }
   public class RegionEdit
    {
        public int RegionID { get; set; }
        public string Regions { get; set; }
    }
   public class RegionListItem
    {
        public int RegionID { get; set; }
        public string Regions { get; set; }
    }
}
