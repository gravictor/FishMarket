using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.ViewModels
{
    public class FishViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string SubCategory { get; set; }
        public string unit { get; set; }
        public string country { get; set; }
        public string img { get; set; }
        public int categoryID { get; set; }
    }
}
