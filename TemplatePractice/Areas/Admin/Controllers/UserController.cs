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
        public UserController(AppDbContext context, UserManager<User> user,
            RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
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
    }
}
