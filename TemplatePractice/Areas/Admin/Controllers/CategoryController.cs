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
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            
            return View(nameof(Index),await _context.Categories.OrderBy(c=>c.Order).ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {            
            return View(await _context.Categories.FindAsync(id));
        }
        public async Task<IActionResult> Update(int id)
        {
            return View(await _context.Categories.FindAsync(id));
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update(int id,Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id!=category.Id)
            {
                return BadRequest();
            }
            bool isExist = await _context.Categories.AnyAsync(c=>c.Id==id);
            if (!isExist)
            {
                return NotFound();
            }
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            bool isExist = await _context.Categories.AnyAsync(c=>c.Id==id);
            if (!isExist)
            {
                return NotFound();
            }

            return View();
        }
        [ActionName("Delete")]
        [HttpPost]
        public async  Task<IActionResult> Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Search(string searchedStr)
        {
            return Json(
                string.IsNullOrWhiteSpace(searchedStr)?
                await _context.Categories.ToListAsync():
                _context.Categories.Where(c=>c.Name.Contains(searchedStr))
                );
        }
    }
}
