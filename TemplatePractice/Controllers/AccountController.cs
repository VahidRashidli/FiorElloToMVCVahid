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
        public readonly SignInManager<User> _signIn;
        public AccountController( UserManager<User> usermanager, SignInManager<User> signIn)
        {
            _usermanager = usermanager;
            _signIn = signIn;
        }
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user = await _usermanager.FindByNameAsync(model.UserName);
            if (user==null)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }
            if (!await _usermanager.CheckPasswordAsync(user,model.Password))
            {
                ModelState.AddModelError(
                    nameof(AccountLoginViewModel.Password),
                    "The password is invalid");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult;
            if (model.KeepSignedIn)
            {
               signInResult=  await _signIn.PasswordSignInAsync(user,model.Password,true,false);
            }
            else
            {
                signInResult = await _signIn.PasswordSignInAsync(user, model.Password, false, false);
            }
            if (!signInResult.Succeeded)
            {
                return View();
            }
            
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var dbUser = await _usermanager.FindByNameAsync(model.UserName);
            if (dbUser!=null)
            {
                ModelState.AddModelError(nameof(RegisterViewModel.UserName),
                    "This username already exists in the database");
                return View();
            }
            User user = new()
            {
                UserName = model.UserName,
                Email=model.Email,
                FullName=model.FullName
            };
            IdentityResult result =await _usermanager.CreateAsync(user,model.Password); 
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _signIn.SignInAsync(user, true);
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
    }
}
