using FishMarket.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Models
{
    public class ShoppingBasketContext: DbContext
    {
        public DbSet<ShoppingBasketViewModel> basket { get; set; }

        public ShoppingBasketContext(DbContextOptions<ShoppingBasketContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
