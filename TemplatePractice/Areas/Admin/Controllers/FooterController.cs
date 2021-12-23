using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.Areas.Admin.Constants;
using TemplatePractice.Areas.Admin.Utilities.File;
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
            if (!footer.File.CheckContent("image"))
            {
                ModelState.AddModelError(nameof(Footer.File), "The file must be an image");
                return View();
            }
            if (!footer.File.CheckFileSizeForGB())
            {
                ModelState.AddModelError(nameof(Footer.File), "The file is too large");
                return View();
            }
         
            
            if (_context.Footers.FirstOrDefault()!=null)
            {
                FileStreamDeleter.DeleteFileStream(
                    FileNameConstants.Image,
                    _context.Footers.FirstOrDefault().Image
                    );
                Guid guid = Guid.NewGuid();
                footer.Image = guid + footer.File.FileName;
                await FileStreamCreator.CreateFileStream(FileNameConstants.Image, footer.File, guid);
                _context.Footers.FirstOrDefault().FacebookLink = footer.FacebookLink;
                _context.Footers.FirstOrDefault().LinkedInLink = footer.LinkedInLink;
                _context.Footers.FirstOrDefault().Image = footer.Image;
            }
            else
            {
                Guid guid = Guid.NewGuid();
                footer.Image = guid + footer.File.FileName;
                await FileStreamCreator.CreateFileStream(FileNameConstants.Image, footer.File, guid);
                await _context.Footers.AddAsync(footer);
            }
            
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
        public async Task<IActionResult> Delete()
        {
            return View(await _context.Footers.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
           
            bool isExist =await _context.Footers.AnyAsync(f=>f.Id==id);
            if (!isExist)
            {
                return NotFound();
            }
            Footer footer = _context.Footers.Find(id);
            FileStreamDeleter.DeleteFileStream(FileNameConstants.Image, footer.Image);
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
        public async Task<IActionResult> Update(int id,Footer footer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!footer.File.CheckContent("image"))
            {
                ModelState.AddModelError(nameof(Footer.File), "The file must be an image");
                return View();
            }
            if (!footer.File.CheckFileSizeForGB())
            {
                ModelState.AddModelError(nameof(Footer.File), "The file is too large");
                return View();
            }
           
            FileStreamDeleter.DeleteFileStream
                (
                FileNameConstants.Image,
                footer.Image
              );
            Guid guid = Guid.NewGuid();
            footer.Image = guid+footer.File.FileName;
           await FileStreamCreator.CreateFileStream(FileNameConstants.Image,footer.File,guid);
            _context.Footers.FirstOrDefault().FacebookLink = footer.FacebookLink;
            _context.Footers.FirstOrDefault().LinkedInLink = footer.LinkedInLink;
            _context.Footers.FirstOrDefault().Image = footer.Image;
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
    }
}
