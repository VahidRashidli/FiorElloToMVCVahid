using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize(Roles = RoleConstants.Admin + "," + RoleConstants.Moderator)]
    public class OwlSliderController : Controller
    {
        private readonly AppDbContext _context;

        public OwlSliderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.OwlSliders.Include(s=>s.Images).FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Create()
        {
            OwlSlider owlSlider = await _context.OwlSliders.Include(s => s.Images).FirstOrDefaultAsync();
            OwlSliderImage owlSliderImage = new OwlSliderImage();
            if (owlSlider!=null)
            {
                ViewData["Info"] = "To create a new owl slider first you need to delete the old one!";
            }
            return View(
                new OwlSliderCreateViewModel
                {
                    OwlSlider=owlSlider,
                    OwlSliderImage=owlSliderImage
                }
                );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OwlSliderCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (viewModel.OwlSlider.File == null)
            {
                ModelState.AddModelError(nameof(OwlSlider), "You must upload a file");
                return View();
            }

            if (viewModel.OwlSliderImage == null)
            {
                ModelState.AddModelError(nameof(OwlSliderImage), "You must upload a slider image");
                return View();
            }
            if (!viewModel.OwlSlider.File.CheckContent("image"))
            {
                ModelState.AddModelError(nameof(OwlSlider.File), "The file must be an image");
                return View();
            }
            if (!viewModel.OwlSliderImage.File.CheckContent("image"))
            {
                ModelState.AddModelError(nameof(OwlSliderImage.File), "The file must be an image");
                return View();
            }
            if (!viewModel.OwlSlider.File.CheckFileSizeForGB())
            {
                ModelState.AddModelError(nameof(OwlSlider.File), "The file is too large");
                return View();
            }
            if (!viewModel.OwlSliderImage.File.CheckFileSizeForGB())
            {
                ModelState.AddModelError(nameof(OwlSliderImage.File), "The file is too large");
                return View();
            }
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
           await FileStreamCreator.CreateFileStream(
               FileNameConstants.Image,
               viewModel.OwlSlider.File,guid1
               );
           await FileStreamCreator.CreateFileStream(
               FileNameConstants.Image, 
               viewModel.OwlSliderImage.File,guid2
               );
            viewModel.OwlSlider.Image = guid1 + viewModel.OwlSlider.File.FileName;
            viewModel.OwlSliderImage.Image = guid2 + viewModel.OwlSliderImage.File.FileName;
            viewModel.OwlSliderImage.slider = viewModel.OwlSlider;
            await _context.OwlSliders.AddAsync(viewModel.OwlSlider);
            await _context.OwlSliderImages.AddAsync(viewModel.OwlSliderImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CreateImage()
        {
            OwlSlider owlSlider = await _context.OwlSliders.FirstOrDefaultAsync();
            if (owlSlider==null)
            {
                ViewBag.Info = "First you need to create an owl slider";
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateImage(SliderImageCreateViewModel sliderImage)
        {
            if (sliderImage.Files==null)
            {
                ModelState.AddModelError(
                    nameof(SliderImageCreateViewModel.Files),
                    "You need to upload at least one image");
                return View();
            }
            foreach(IFormFile file in sliderImage.Files) 
            {
                
            if (!file.CheckContent("image"))
             {
                ModelState.AddModelError(nameof(SliderImageCreateViewModel.Files)
                    , "The file must be an image");
                return View();
            }
            if (!file.CheckFileSizeForGB())
            {
                ModelState.AddModelError(nameof(SliderImageCreateViewModel.Files),
                    "The file is too large");
                return View();
            }
                OwlSliderImage owlSliderImage = new OwlSliderImage
                {
                    File = file
                };
                Guid guid = Guid.NewGuid();
            await FileStreamCreator.CreateFileStream(FileNameConstants.Image, owlSliderImage.File, guid);
            owlSliderImage.Image = guid + owlSliderImage.File.FileName;
            owlSliderImage.slider = await _context.OwlSliders.FirstOrDefaultAsync();
            await _context.OwlSliderImages.AddAsync(owlSliderImage);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateSliderImage(int id)
        {
            return View(await _context.OwlSliderImages.FindAsync(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSliderImage(int id,OwlSliderImage slideImage)
        {
            if (id!=slideImage.Id)
            {
                return BadRequest();
            }
            if (slideImage.File!=null)
            {
                if (!slideImage.File.CheckContent("image"))
                {
                    ModelState.AddModelError(nameof(OwlSliderImage.File), "The file must be an image");
                    return View();
                }
                if (!slideImage.File.CheckFileSizeForGB())
                {
                    ModelState.AddModelError(nameof(OwlSliderImage.File), "The file is too large");
                    return View();
                }
                FileStreamDeleter.DeleteFileStream(FileNameConstants.Image, slideImage.Image);
                Guid guid = Guid.NewGuid();
                await FileStreamCreator.CreateFileStream(FileNameConstants.Image, slideImage.File, guid);
                slideImage.Image = guid+slideImage.File.FileName;
                _context.OwlSliderImages.Update(slideImage);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
            
        }
        public async Task<IActionResult> Update()
        {
            return View(await _context.OwlSliders.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id , OwlSlider owlSlider)
        {
            if (id!=owlSlider.Id)
            {
                return BadRequest();
            }
            if (!await _context.OwlSliders.AnyAsync(s=>s.Id==id))
            {
                return NotFound();
            }
            if (owlSlider.File!=null)
            {
                if (!owlSlider.File.CheckContent("image"))
                {
                    ModelState.AddModelError(nameof(OwlSlider.File), "The file must be an image");
                    return View();
                }
                if (!owlSlider.File.CheckFileSizeForGB())
                {
                    ModelState.AddModelError(nameof(OwlSlider.File), "The file is too large");
                    return View();
                }
                Guid guid = Guid.NewGuid();
                FileStreamDeleter.DeleteFileStream(FileNameConstants.Image, owlSlider.Image);
                await FileStreamCreator.CreateFileStream(FileNameConstants.Image, owlSlider.File, guid);
                owlSlider.Image = guid + owlSlider.File.FileName;
            }
            _context.OwlSliders.Update(owlSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail()
        {
            return View(await _context.OwlSliders.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> DetailSliderImage(int id)
        {
            return View(await _context.OwlSliderImages.FindAsync(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            OwlSlider owlSlider = await _context.OwlSliders.Include(s=>s.Images).FirstOrDefaultAsync();
            if (owlSlider.Images.Count>0)
            {
                TempData["Info"] = "First you need to delete all the images!";
            }
            return View(owlSlider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            OwlSlider owlSlider = await _context.OwlSliders.FindAsync(id);
            FileStreamDeleter.DeleteFileStream(FileNameConstants.Image, owlSlider.Image);
            _context.OwlSliders.Remove(owlSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteSliderImage(int id)
        {
            OwlSliderImage owlSliderImage = await _context.OwlSliderImages.FindAsync(id);
            if (owlSliderImage == null)
            {
                return NotFound();
            }
            return View(owlSliderImage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteSliderImage")]
        public async Task<IActionResult> DeleteSliderImageAsync(int id)
        {
            OwlSliderImage owlSliderImage = await _context.OwlSliderImages.FindAsync(id);
            FileStreamDeleter.DeleteFileStream(FileNameConstants.Image, owlSliderImage.Image);
            _context.OwlSliderImages.Remove(owlSliderImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
