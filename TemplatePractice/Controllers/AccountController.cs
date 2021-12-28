using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemplatePractice.DAL;
using TemplatePractice.Models;
using TemplatePractice.ViewModels;

namespace TemplatePractice.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<User> _usermanager;
        public AccountController( UserManager<User> usermanager)
        {
            _usermanager = usermanager;
        }
        public  IActionResult Login(User user)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var dbUser = await _usermanager.FindByNameAsync(user.UserName);
            if (dbUser!=null)
            {
                ModelState.AddModelError(nameof(RegisterViewModel.UserName),
                    "This username already exists in the database");
            }
            var result =await _usermanager.CreateAsync(
                new User() { 
                UserName=user.UserName,
                Email=user.Email,
                FullName=user.FullName,
                },user.Password
                ); 
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
             
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
    }
}
