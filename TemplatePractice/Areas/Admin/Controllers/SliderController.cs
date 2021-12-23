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
using TemplatePractice.Areas.Admin.Utilities.File;
using TemplatePractice.Areas.Admin.Constants;

namespace TemplatePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env )
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
            if (!image.File.CheckContent("image"))
            {
                ModelState.AddModelError(nameof(ExpertImage.File), "The file is not an image");
                return View();
            }
            if (!image.File.CheckFileSizeForGB())
            {
                ModelState.AddModelError(nameof(ExpertImage.File), "The file is too large");
                return View();
            }
            Guid guid = Guid.NewGuid();
            image.ImageName = guid+image.File.FileName;
            await FileStreamCreator.CreateFileStream(FileNameConstants.Image,image.File, guid);
            await _context.ExpertImages.AddAsync(image);
            await  _context.SaveChangesAsync();
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
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            ExpertImage expertImage = await _context.ExpertImages.FindAsync(id);
            if (id!=expertImage.Id)
            {
                return BadRequest();
            }
            FileStreamDeleter.DeleteFileStream(FileNameConstants.Image, expertImage.ImageName);
            _context.ExpertImages.Remove(expertImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
