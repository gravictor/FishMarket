using FishMarket.Interfaces;
using FishMarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public FishController(IAllFish iallFish, IFishCategory ifishCat)
        {
            _allCategories = ifishCat;
            _allFish = iallFish;
        }

        public ViewResult List()
        {
            FishListViewModel obj = new FishListViewModel();
            obj.allFish = _allFish.Fish;
            obj.currCategory = "Рыба";
            return View(obj);
        }

    }
}
