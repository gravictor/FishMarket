using FishMarket.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Models
{
    public class FishContext: DbContext
    {
        public DbSet<FishViewModel> fish { get; set; }

        public FishContext(DbContextOptions<FishContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
