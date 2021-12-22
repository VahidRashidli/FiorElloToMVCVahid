using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpertImages.ToListAsync());;
        }
        public IActionResult Create()
        {
           
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpertImage image)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!image.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(ExpertImage.File), "The file is not an image");
                return View();
            }
            if (image.File.Length>1024*1000)
            {
                ModelState.AddModelError(nameof(ExpertImage.File), "The file is too large");
                return View();
            }
            image.ImageName = image.File.FileName;
            string path = Path.Combine(_env.WebRootPath, "img",image.File.FileName);
            FileStream fileStream = new FileStream(path,FileMode.Create);
            await image.File.CopyToAsync(fileStream);
            await _context.ExpertImages.AddAsync(image);
           await  _context.SaveChangesAsync();
            fileStream.Close();
            return View(nameof(Index),await _context.ExpertImages.ToListAsync());
        }
        public async Task<IActionResult>Delete(int id)
        {
            ExpertImage expertImage = await _context.ExpertImages.FindAsync(id);
            if (expertImage==null)
            {
                return NotFound();
            }
            return View(expertImage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id , ExpertImage expertImage)
        {
            if (id!=expertImage.Id)
            {
                return BadRequest();
            }
            _context.ExpertImages.Remove(expertImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
