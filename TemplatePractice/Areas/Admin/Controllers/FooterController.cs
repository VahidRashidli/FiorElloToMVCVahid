using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.Areas.Admin.ViewModels;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterController : Controller
    {
        private readonly AppDbContext _context;

        public FooterController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(new FooterIndexViewModel { 
                Footer=await _context.Footers.FirstOrDefaultAsync(),
                FooterCategories=await _context.FooterCategories.ToListAsync(),
                FooterCategorySections=await _context.FooterCategorySections.ToListAsync()                
            });
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Footer footer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Footers.FirstOrDefault().FacebookLink = footer.FacebookLink;
            _context.Footers.FirstOrDefault().LinkedInLink= footer.LinkedInLink;
            await _context.SaveChangesAsync();
            return View(nameof(Index),
                new FooterIndexViewModel
                {
                    Footer = await _context.Footers.FirstOrDefaultAsync(),
                    FooterCategories = await _context.FooterCategories.ToListAsync(),
                    FooterCategorySections = await _context.FooterCategorySections.ToListAsync()
                }
                );
        }
    }
}
