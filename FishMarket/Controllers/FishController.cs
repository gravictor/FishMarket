using FishMarket.Interfaces;
using FishMarket.Models;
using FishMarket.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        UserManager<User> _userManager;
        private FishContext db;
        private OrderContext orderDb;

        public FishController(IAllFish iallFish, IFishCategory ifishCat, FishContext context, OrderContext contextDb, UserManager<User> userManager)
        {
            db = context;
            orderDb = contextDb;
            _allCategories = ifishCat;
            _allFish = iallFish;
            _userManager = userManager;
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
        public async Task<IActionResult> OrderAsync(string Email, string prname)
        {
            var product = db.fish.AsNoTracking();
            Fish fish = new Fish();
            foreach (var item in product)
            {
                if (item.name == prname)
                {
                    fish.name = item.name;
                    fish.price = item.price;
                }
            }
            User user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound();
            }
            OrderViewModel model = new OrderViewModel { Id = user.Id, Name = user.Name, Email = user.Email, PhoneNumber = user.PhoneNumber, Price = fish.price, ProductName = fish.name };

            return View(model);
        }
        [HttpPost]
        public IActionResult Order(OrderViewModel Orders)
        {
            orderDb.order.Add(Orders);
            orderDb.SaveChanges();
            return View();
        }
    }
}
