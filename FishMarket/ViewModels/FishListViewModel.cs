using FishMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.ViewModels
{
    public class FishListViewModel
    {
        public IEnumerable<Fish> allFish { get; set; }
        public string currCategory { get; set; }
    }
}
