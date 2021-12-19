using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.DAL;
using TemplatePractice.Models;
using TemplatePractice.ViewModels;

namespace TemplatePractice.ViewComponents
{
    public class InstagramSectionViewComponent:ViewComponent
    {
        private IAppDbContext _context;

        public InstagramSectionViewComponent(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new InstagramSectionViewModel {
                InstagramSection= await _context.InstagramSections.FirstOrDefaultAsync(),
                InstagramSectionPictures=await _context.InstagramSectionPictures.ToListAsync()
        });
        }
    }
}
