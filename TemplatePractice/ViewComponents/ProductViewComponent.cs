using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice
{
    public class ProductViewComponent:ViewComponent
    {
        private IAppDbContext _context;
        public ProductViewComponent(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ICollection<Product> products = await _context.Products.Take(8).ToListAsync();
            return View(products);
        }
    }
}
