using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplatePractice.DAL;

namespace TemplatePractice.ViewComponents
{
    public class SayViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public SayViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            return View(_context.SaySections.ToList());
        }
    }
}
