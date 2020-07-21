using FishMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Interfaces
{
    public interface IFishCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
