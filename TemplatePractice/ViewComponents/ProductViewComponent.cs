using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice
{
    public class ProductViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ICollection<Product> products = _context.Products.Take(8).ToList();
            return View(products);
        }
    }
}
