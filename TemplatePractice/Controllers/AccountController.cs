using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice.Controllers
{
    public class AccountController:Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _usermanager;

        
        public AccountController(AppDbContext context, UserManager<User> usermanager)
        {
            _context = context;
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
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result =await _usermanager.CreateAsync(
                new User() { UserName=user.UserName,
                Email=user.Email,
                },user.PasswordHash
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
