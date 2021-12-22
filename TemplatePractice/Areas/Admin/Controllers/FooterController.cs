using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;
        public FooterController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(new FooterIndexViewModel { 
                Footer=await _context.Footers.FirstOrDefaultAsync(),
                FooterCategories=await _context.FooterCategories.ToListAsync(),
                FooterCategorySections=await _context.FooterCategorySections.ToListAsync()                
            });
        }
        public IActionResult Create()
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
            if (!footer.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(Footer.File), "The file must be an image");
                return View();
            }
            if (footer.File.Length>1024*1000)
            {
                ModelState.AddModelError(nameof(Footer.File), "The file is too large");
                return View();
            }
            footer.Image = footer.File.FileName;
            string path = Path.Combine(_env.WebRootPath, "img", Guid.NewGuid() + footer.Image);
            FileStream fileStream = new FileStream(path, FileMode.Create);
            await footer.File.CopyToAsync(fileStream);
            if (_context.Footers.FirstOrDefault()!=null)
            {
                _context.Footers.FirstOrDefault().FacebookLink = footer.FacebookLink;
                _context.Footers.FirstOrDefault().LinkedInLink = footer.LinkedInLink;
                _context.Footers.FirstOrDefault().Image = footer.Image;
            }
            else
            {
                await _context.Footers.AddAsync(new Footer
                {
                    FacebookLink = footer.FacebookLink,
                    Image=footer.Image,
                    LinkedInLink=footer.LinkedInLink
                });
            }
            
            await _context.SaveChangesAsync();
            fileStream.Close();
            return View(nameof(Index),
                new FooterIndexViewModel
                {
                    Footer = await _context.Footers.FirstOrDefaultAsync(),
                    FooterCategories = await _context.FooterCategories.ToListAsync(),
                    FooterCategorySections = await _context.FooterCategorySections.ToListAsync()
                }
                );
        }
        public async Task<IActionResult> Delete()
        {
            return View(await _context.Footers.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Footer footer)
        {
            if (id != footer.Id)
            {
                return BadRequest();
            }
            bool isExist =await _context.Footers.AnyAsync(f=>f.Id==footer.Id);
            if (!isExist)
            {
                return NotFound();
            }
           
            _context.Footers.Remove(footer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update()
        {
            return View(await _context.Footers.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Footer footer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!footer.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(Footer.File), "The file must be an image");
                return View();
            }
            if (footer.File.Length > 1024 * 1000)
            {
                ModelState.AddModelError(nameof(Footer.File), "The file is too large");
                return View();
            }
            footer.Image = footer.File.FileName;
            string path = Path.Combine(_env.WebRootPath, "img", Guid.NewGuid()+footer.Image); ;
            FileStream fileStream = new FileStream(path, FileMode.Create);
            await footer.File.CopyToAsync(fileStream);
                _context.Footers.FirstOrDefault().FacebookLink = footer.FacebookLink;
                _context.Footers.FirstOrDefault().LinkedInLink = footer.LinkedInLink;
                _context.Footers.FirstOrDefault().Image = footer.Image;
            fileStream.Close();
                return View(await _context.Footers.FirstOrDefaultAsync());
        }
    }
}
