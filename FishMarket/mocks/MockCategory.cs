using FishMarket.Interfaces;
using FishMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.mocks
{
    public class MockCategory : IFishCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ categoryName="Мороженная рыба", desc=""},
                    new Category{ categoryName="Морепродукты", desc=""},
                    new Category{ categoryName="Свежая рыба", desc=""},
                    new Category{ categoryName="Копченная рыба", desc=""},
                    new Category{ categoryName="Вяленая рыба", desc=""},
                    new Category{ categoryName="Снеки", desc=""},
                    new Category{ categoryName="Прессеры", desc=""},
                    new Category{ categoryName="Икра", desc=""},
                    new Category{ categoryName="Консервы", desc=""},
                    new Category{ categoryName="Всё для суши", desc=""}
                };
            }
        }
    }
}
