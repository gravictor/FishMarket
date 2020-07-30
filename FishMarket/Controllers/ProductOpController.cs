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
    public class ProductOpController: Controller
    {

        UserManager<User> _userManager;
        private FishContext db;
        public ProductOpController(FishContext context, UserManager<User> userManager) 
        {
            _userManager = userManager;
            db = context;
        }
        public IActionResult Index()
        {
            var data = db.fish.AsNoTracking().ToList();
            return View(data);
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(FishViewModel model)
        {
            var data = db.fish.AsNoTracking().ToList();
            model.id = data.Count;
            model.id = model.id+1;
            for (int i = 0; i < data.Count-1; i++)
            {
                for (int j = i+1; j < data.Count; j++)
                {
                    if (data[i].id==model.id)
                    {
                        Random random = new Random();
                        int value = random.Next(100, 10000);
                        model.id += value;
                    }
                }
            }
            db.fish.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            var data = db.fish.AsNoTracking().ToList();
            FishViewModel model = new FishViewModel();
            foreach (var obj in data)
            {
                if (obj.id.ToString() == id)
                {
                    FishViewModel fishId = new FishViewModel { id = obj.id, name = obj.name, country = obj.country, categoryID = obj.categoryID, img = obj.img, price = obj.price, SubCategory = obj.SubCategory, unit = obj.unit };
                    model = fishId;
                }
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(FishViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fish = db.fish.AsNoTracking().ToList();
                FishViewModel selectedObj = new FishViewModel();
                foreach (var obj in fish)
                {
                    if (obj.id == model.id)
                    {
                        selectedObj = obj;
                    }
                }
                if (fish != null)
                {
                    selectedObj.name = model.name;
                    selectedObj.country = model.country;
                    selectedObj.categoryID = model.categoryID;
                    selectedObj.price = model.price;
                    selectedObj.unit = model.unit;
                    selectedObj.img = model.img;
                    selectedObj.SubCategory = model.SubCategory;

                    db.Update(selectedObj);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var data = db.fish.AsNoTracking().ToList();
            FishViewModel model = new FishViewModel();
            foreach (var obj in data)
            {
                if (obj.id.ToString() == id)
                {
                    FishViewModel fishId = new FishViewModel { id = obj.id, name = obj.name, country = obj.country, categoryID = obj.categoryID, img = obj.img, price = obj.price, SubCategory = obj.SubCategory, unit = obj.unit };
                    model = fishId;
                }
            }
            if (model != null)
            {
                db.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
