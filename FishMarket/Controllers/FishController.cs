using FishMarket.Interfaces;
using FishMarket.Models;
using FishMarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Controllers
{
    public class FishController: Controller
    {
        private readonly IAllFish _allFish;
        private readonly IFishCategory _allCategories;
        private FishContext db;

        public FishController(IAllFish iallFish, IFishCategory ifishCat, FishContext context)
        {
            db = context;
            _allCategories = ifishCat;
            _allFish = iallFish;
        }

        public ViewResult List()
        {
            var data = db.fish.AsNoTracking().ToList();
            return View(data);
        }
        public ViewResult FrozenFish()
        {
            FishListViewModel obj = new FishListViewModel();
            FishListViewModel res = new FishListViewModel();
            obj.currCategory = _allCategories.AllCategories;
            foreach (var item in obj.currCategory)
            {
                if (item.categoryName=="Мороженная рыба")
                {
                    res.allFish = _allFish.Fish;
                    foreach (var r in obj.allFish)
                    {
                        if (r.Category == item)
                        {

                        }
                    }
                }
            }
            return View(obj);
        }

    }
}
