using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAnywhere.Models
{
    public class PropertyCreate
    {
        public int LocationID { get; set; }
        public string Properties { get; set; }
    }
    public class PropertyDetail
    {
        public int PropertyID { get; set; }
        public string Properties { get; set; }
    }
    public class PropertyEdit
    {
        public int PropertyID { get; set; }
        public int LocationID { get; set; }
        public string Properties { get; set; }
    }
    public class PropertyListItem
    {
        public int PropertyID { get; set; }
        public string Properties { get; set; }
    }
}

