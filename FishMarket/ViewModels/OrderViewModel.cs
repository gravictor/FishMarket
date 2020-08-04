using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public string unit { get; set; }
    }
}
