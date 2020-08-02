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
        
        public IActionResult ChoosenFish(string id)
        {
            FishListViewModel obj = new FishListViewModel();
            var data = db.fish.AsNoTracking().ToList();
            obj.currCategory = _allCategories.AllCategories;
            List<FishViewModel> res = new List<FishViewModel>();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 1; j < obj.currCategory.ToList().Count+1; j++)
                {
                    if (data[i].categoryID==Convert.ToInt32(id))
                    {
                        res.Add(data[i]);
                        break;
                    }
                }
            }
            return View(res);
        }

    }
}
