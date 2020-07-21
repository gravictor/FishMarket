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
        public ushort price { get; set; }
        public string subCategory { get; set; }
        public string unit { get; set; }
        public string country { get; set; }
        public string img { get; set; }
        public int categoryID { get; set; }
        public virtual Category Category { get; set; } 
    }
}
