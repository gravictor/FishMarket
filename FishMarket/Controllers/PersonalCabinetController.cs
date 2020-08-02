using FishMarket.Models;
using FishMarket.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarket.Controllers
{
    public class PersonalCabinetController: Controller
    {
        UserManager<User> _userManager;
        public PersonalCabinetController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ChangePassword(string Email)
        {
            User user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);

        }
    }
}
