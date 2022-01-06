﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.Areas.Admin.Constants;
using TemplatePractice.DAL;

namespace TemplatePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =RoleConstants.Admin+","+RoleConstants.Moderator)]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {

            return View();
        }
       
    }
}
