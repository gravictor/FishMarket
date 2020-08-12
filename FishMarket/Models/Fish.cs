using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Models
{
    public class Fish
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string IsPromotionalItem { get; set; }
        public string SeasonItem { get; set; }
        public string price { get; set; }
        public string subCategory { get; set; }
        public string unit { get; set; }
        public string country { get; set; }
        public string img { get; set; }
        public int categoryID { get; set; }
    }
}
