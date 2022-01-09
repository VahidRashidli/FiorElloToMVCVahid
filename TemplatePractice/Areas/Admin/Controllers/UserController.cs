using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.Areas.Admin.Constants;
using TemplatePractice.Areas.Admin.ViewModels;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =RoleConstants.Admin+","+RoleConstants.Moderator)]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _user;
        private readonly RoleManager<IdentityRole> _role;
        private readonly SignInManager<User> _signIn;
        public UserController(AppDbContext context, UserManager<User> user,
            RoleManager<IdentityRole> role, SignInManager<User> signIn)
        {
            _context = context;
            _user = user;
            _role = role;
            _signIn = signIn;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<User> users = await _context.Users.ToListAsync();
            List<UserViewModel> userVMs = new List<UserViewModel>();
            foreach (User user in users)
            {
                userVMs.Add(new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    UserName = user.FullName,
                    RoleNames = (await _user.GetRolesAsync(user)).ToList()
                });
            }
            return View(userVMs);
        }
        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            User user = await _user.FindByIdAsync(id);
            return View(new AddRoleViewModel
            {
                User = new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    UserName = user.FullName,
                    RoleNames = (await _user.GetRolesAsync(user)).ToList()
                },
                Roles =await _role.Roles.ToListAsync()
            }); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string id,AddRoleViewModel model)
        {
            if (model.Role==null)
            {
                return RedirectToAction(nameof(Index));
            }
           await _user.AddToRoleAsync(
                await _user.FindByIdAsync(id),
                model.Role
                );
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _user.FindByIdAsync(id);
            if (user == null) return NotFound();
            return View(new PasswordViewModel
            {
                Id=user.Id,
                UserName=user.UserName
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(PasswordViewModel model,string id)
        {
            PasswordViewModel passwordViewModel = new PasswordViewModel
            {
                Id = model.Id,
                UserName=model.UserName
            };
            User user = await _user.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (!ModelState.IsValid) return View(passwordViewModel);
            if (!await _user.CheckPasswordAsync(user,model.OldPassword))
            {
                ModelState.AddModelError(nameof(PasswordViewModel.OldPassword), 
                    "The old password is incorrect!"
                    );
                return View(passwordViewModel);
            }
           IdentityResult result=await _user.ChangePasswordAsync(user, 
               model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(passwordViewModel);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> BlockUser(string id) 
        {
            User user = await _user.FindByIdAsync(id);
            if (user == null) return NotFound();
           await _user.SetLockoutEnabledAsync(user, true);
            await _user.SetLockoutEndDateAsync(user,DateTimeOffset.Parse("10/10/2022"));
            await _user.UpdateSecurityStampAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
