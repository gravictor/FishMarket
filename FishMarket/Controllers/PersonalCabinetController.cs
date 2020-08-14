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
    public class PersonalCabinetController: Controller
    {
        private OrderContext db;
        private ShoppingBasketContext shbasket;
        UserManager<User> _userManager;
        public PersonalCabinetController(ShoppingBasketContext basket, UserManager<User> userManager, OrderContext context)
        {
            shbasket = basket;
            db = context;
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var _passwordValidator =
                    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    IdentityResult result =
                    await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
        public IActionResult MyOrders()
        {
            var data = shbasket.basket.AsNoTracking().ToList();
            foreach (var item in data)
            {
                if (item.Email=="valeramail.ru")
                {
                    shbasket.Remove(item);
                    shbasket.SaveChanges();
                }
            }
            return View(data);
        }
        public IActionResult AdminOrder()
        {
            var data = db.order.AsNoTracking().ToList();
            return View(data);
        }
        public IActionResult ProcessedOrder(string id)
        {
            var data = db.order.AsNoTracking().ToList();
            foreach (var item in data)
            {
                if (item.Id == id)
                {
                    item.IsOrderProcessed = "+";
                    db.Update(item);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("AdminOrder");
        }
        public IActionResult Edit(string id)
        {
            var basket = shbasket.basket.ToList();
            ShoppingBasketViewModel choosenItem = new ShoppingBasketViewModel();
            foreach (var item in basket)
            {
                if (item.Id ==id)
                {
                    ShoppingBasketViewModel model = new ShoppingBasketViewModel { Id = item.Id, Count = item.Count, Name = item.Name, Email=item.Email, PhoneNumber = item.PhoneNumber, Price = item.Price, ProductName = item.ProductName, unit = item.unit};
                    choosenItem = model;
                }
            }
            
            return View(choosenItem);
        }

        [HttpPost]
        public IActionResult Edit(ShoppingBasketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = shbasket.basket.AsNoTracking().ToList();
                ShoppingBasketViewModel selectedObj = new ShoppingBasketViewModel();
                foreach (var obj in item)
                {
                    if (obj.Id == model.Id)
                    {
                        selectedObj = obj;
                    }
                }
                if (item != null)
                {
                    selectedObj.Id = model.Id;
                    selectedObj.PhoneNumber = model.PhoneNumber;
                    selectedObj.Count = model.Count;

                    shbasket.Update(selectedObj);
                    shbasket.SaveChanges();
                }
            }
            return RedirectToAction("MyOrders");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var basket =  shbasket.basket.ToList();
            foreach (var item in basket)
            {
                if (item.Id == id)
                {
                    shbasket.Remove(item);
                    shbasket.SaveChanges();
                }
            }
            return RedirectToAction("MyOrders");
        }
    }
}
