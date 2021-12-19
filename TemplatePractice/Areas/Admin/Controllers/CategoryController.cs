using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.OrderBy(c=>c.Order).ToListAsync());
        }
        
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            
            return View(nameof(Index),await _context.Categories.OrderBy(c=>c.Order).ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {            
            return View(await _context.Categories.FindAsync(id));
        }
    }
}
