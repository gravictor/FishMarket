using FishMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Interfaces
{
    public interface IAllFish
    {
        IEnumerable<Fish> Fish { get; }
        Fish getObjectFish(int fishID);
    }
}
