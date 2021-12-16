using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TemplatePractice.DAL;
using TemplatePractice.Models;
using TemplatePractice.ViewModels;


namespace TemplatePractice.Controllers
{
    public class ProductController : Controller
    {

            private AppDbContext _context;
            public ProductController(AppDbContext context)
            {
                _context = context;
            }
        public async Task<List<ProductCardViewModel>> AddToBasket(int id)
        {
            List<ProductCardViewModel> basket = GetBasket();
            Product product=(await _context.Products.FindAsync(id));
            if (basket.Exists(p=>p.Id==product.Id))
            {
                basket.Find(p => p.Id ==product.Id).Count++;
            }
            else
            {
                basket.Add(new ProductCardViewModel() {
                Id=product.Id,
                Category=product.Category,
                Count=1,
                ImageName=product.ImageName,
                Name=product.Name,
                Price=product.Price
                });
            }
            Response.Cookies.Append("basket",JsonConvert.SerializeObject(basket));
            return basket;
        }
        public  List<ProductCardViewModel> GetBasket()
        {
            
            List<ProductCardViewModel> basket;
            if (Request.Cookies["basket"] == null)
            {
                basket = new List<ProductCardViewModel>();
            }
            else
            {
                basket =  JsonConvert
                    .DeserializeObject<List<ProductCardViewModel>>(Request.Cookies["basket"]);
            }
            return basket;
        }
        public async Task SynchronizeCookieWithDataBase()
        {
            List<ProductCardViewModel> basket = GetBasket();
            if (basket.Count != 0)
            {
                foreach(ProductCardViewModel basketProduct in basket)
                {
                    Product product =await _context.Products.Where(p => p.Id == basketProduct.Id).FirstOrDefaultAsync();
                    if (product!=null)
                    {
                        basketProduct.ImageName = product.ImageName;
                        basketProduct.Name = product.Name;
                        basketProduct.Price = product.Price;                        
                    }
                    
                }              
                Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            }
        }
            public IActionResult Index()
            {

                int count = 0;
                AboutSection aboutSection = _context.AboutSections.FirstOrDefault();
                ICollection<InfoList> infoLists = _context.InfoLists.ToList();
                ICollection<Product> products = _context.Products.Include(p => p.Category).Skip(count).Take(4).ToList();
                ICollection<Category> categories = _context.Categories.OrderBy(x => x.Order).ToList();
                Subscribe subscribe = _context.Subscribes.FirstOrDefault();
                ExpertSection expertSection = _context.ExpertSections.FirstOrDefault();
                ICollection<ExpertImage> expertImages = _context.ExpertImages.OrderBy(i => i.Order).ToList();
                return View(new HomeIndexViewModel { AboutSection = aboutSection, InfoLists = infoLists, Categories = categories, Products = products, Subscribe = subscribe, ExpertImages = expertImages, ExpertSection = expertSection });
            }
        public IActionResult GetPartial(int count)
        {
          
            ICollection<Product> products = _context.Products.Include(p => p.Category).Skip(count).Take(2).ToList();
            
            return Json(products);
        }
        public async Task<IActionResult> Search(string searchedStr)
        {
            if (string.IsNullOrWhiteSpace(searchedStr))
            {
                return PartialView("_ProductSearchPartial", new List<Product>());
            }
            List<Product> products = await _context.Products
                .Where(p => p.Name.ToLower().StartsWith(searchedStr.ToLower())).Take(5).ToListAsync();
            if (products.Count==0)
            {
                ViewBag.ProductCount = 0;
            }
            return PartialView("_ProductSearchPartial",products);
        }

    }
}
