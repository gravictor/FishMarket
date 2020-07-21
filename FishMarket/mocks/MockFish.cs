using FishMarket.Interfaces;
using FishMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.mocks
{
    public class MockFish : IAllFish
    {
        private readonly IFishCategory _categoryFish = new MockCategory();

        public IEnumerable<Fish> Fish
        {
            get
            {
                return new List<Fish>
                {
                    new Fish{
                        name="Acula",
                        price=200,
                        unit="шт",
                        country="South Africa",
                        Category = _categoryFish.AllCategories.Last() 
                    },
                    new Fish{
                        name="Тюлька",
                        price=50,
                        subCategory = "Столовая",
                        unit="кг",
                        country="UA",
                        Category = _categoryFish.AllCategories.First()
                    }
                };
            }
        }

        public Fish getObjectFish(int fishID)
        {
            throw new NotImplementedException();
        }
    }
}
