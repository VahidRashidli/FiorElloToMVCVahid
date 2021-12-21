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
    public class FooterViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {           
            return View(new FooterInvokeViewModel {
                Footer=_context.Footers.FirstOrDefault(),
                FooterCategories=_context.FooterCategories.Include(fc=>fc.footerCategorySections).ToList(),
                FooterCategorySections=_context.FooterCategorySections.ToList()
            });
        }
    }
}
