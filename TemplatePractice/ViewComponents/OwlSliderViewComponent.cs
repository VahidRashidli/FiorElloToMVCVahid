using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.DAL;

namespace TemplatePractice.ViewComponents
{
    public class OwlSliderViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public OwlSliderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.OwlSliders.Include(s=>s.Images).FirstOrDefaultAsync());
        }
    }
}
