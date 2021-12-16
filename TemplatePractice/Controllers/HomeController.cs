using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.DAL;
using TemplatePractice.Models;
using TemplatePractice.ViewModels;

namespace TemplatePractice.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {                       
            AboutSection aboutSection = _context.AboutSections.FirstOrDefault();
            ICollection<InfoList> infoLists = _context.InfoLists.ToList();
            #region Footer
            //_context.Footers.AddRange(new Footer
            //{
            //    FacebookLink = "https://www.facebook.com/shamilzada.bakhtiyar",
            //    LinkedInLink = "https://www.linkedin.com/in/bakhtiyar-shamilzada-145159185",
            //    Image = "footer-bottom-1.png"
            //});
            //FooterCategory footerCategory1 = new FooterCategory { Name = "Customer Service" };
            //FooterCategory footerCategory2 = new FooterCategory { Name = "COMPANY" };
            //FooterCategory footerCategory3 = new FooterCategory { Name = "SOCIAL MEDIA" };
            // FooterCategory footerCategory4 = new FooterCategory { Name = "ARCHIVE" };
            //_context.FooterCategories.AddRange(footerCategory1, footerCategory2,footerCategory3,footerCategory4);
            //_context.FooterCategorySections.AddRange(
            //    new FooterCategorySection { Name = "Help & Contact Us", FooterCategory =footerCategory1 ,Link="" },
            //     new FooterCategorySection { Name = "Returns & Refunds", FooterCategory = footerCategory1, Link = "" },
            //      new FooterCategorySection { Name = "Online Stores", FooterCategory = footerCategory1, Link = "" },
            //       new FooterCategorySection { Name = "Terms & Conditions", FooterCategory = footerCategory1, Link = "" },

            //       new FooterCategorySection { Name = "About Us", FooterCategory = footerCategory2, Link = "" },
            //       new FooterCategorySection { Name = "Blog", FooterCategory = footerCategory2, Link = "" },
            //       new FooterCategorySection { Name = "Order Tracking", FooterCategory = footerCategory2, Link = "" },
            //       new FooterCategorySection { Name = "FAQ Page", FooterCategory = footerCategory2, Link = "" },
            //       new FooterCategorySection { Name = "Contact Us", FooterCategory = footerCategory2, Link = "" },
            //       new FooterCategorySection { Name = "Login", FooterCategory = footerCategory2, Link = "" },

            //       new FooterCategorySection { Name = "Twitter", FooterCategory = footerCategory3, Link = "" },
            //       new FooterCategorySection { Name = "Instagram", FooterCategory = footerCategory3, Link = "" },
            //       new FooterCategorySection { Name = "Tumblr", FooterCategory = footerCategory3, Link = "" },
            //       new FooterCategorySection { Name = "Pinterest", FooterCategory = footerCategory3, Link = "" },

            //       new FooterCategorySection { Name = "Designer Shoes", FooterCategory = footerCategory4, Link = "" },
            //       new FooterCategorySection { Name = "Gallery", FooterCategory = footerCategory4, Link = "" },
            //       new FooterCategorySection { Name = "Pricing", FooterCategory = footerCategory4, Link = "" },
            //       new FooterCategorySection { Name = "Feature Index", FooterCategory = footerCategory4, Link = "" },
            //       new FooterCategorySection { Name = "Login", FooterCategory = footerCategory4, Link = "" },
            //       new FooterCategorySection { Name = "Help & Support", FooterCategory = footerCategory4, Link = "" }

            //    ); ;
            //_context.SaveChanges();
            #endregion
            #region AddingBlogAndSaySections
            //_context.Blogs.Add(new Blog { Title = "From our Blog", Description = "A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you." });
            //_context.BlogPictures.AddRange(
            //    new BlogPicture { Date = DateTime.Now, Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", Title = "Flower Power", Image = "blog-feature-img-1.jpg" },
            //    new BlogPicture { Date = DateTime.Now, Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", Title = "Local Florists", Image = "blog-feature-img-3.jpg" },
            //     new BlogPicture { Date = DateTime.Now, Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", Title = "Flower Beauty", Image = "blog-feature-img-4.jpg" }
            //    );
            //_context.SaySections.AddRange(
            //    new SaySection { Image = "testimonial-img-1.png", Description = "Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus lingua.", PersonName = "Anna Barnes", Profession = "Florist" },
            //    new SaySection { Image = "testimonial-img-2.png", Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget.", PersonName = "Jasmine White", Profession = "Florist" }
            //    );
            //_context.SaveChanges();
            #endregion
            #region Adding Instagram Section
            //_context.InstagramSections.Add(new InstagramSection { Title = "#FIORELLO" });
            //_context.InstagramSectionPictures.AddRange(
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram1.jpg" },
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram2.jpg" },
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram3.jpg" },
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram4.jpg" },
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram5.jpg" },
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram6.jpg" },
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram7.jpg" },
            //    new InstagramSectionPicture { CreatedDate = DateTime.Now, ImageName = "instagram8.jpg" }
            //    );
            
            #endregion
            ICollection<Product> products = _context.Products.Include(p=>p.Category).Take(8).ToList();
            ICollection<Category> categories = _context.Categories.OrderBy(x => x.Order).ToList();
            Subscribe subscribe = _context.Subscribes.FirstOrDefault();
            ExpertSection expertSection = _context.ExpertSections.FirstOrDefault();
            ICollection<ExpertImage> expertImages = _context.ExpertImages.OrderBy(i=>i.Order).ToList();
            Blog blog = _context.Blogs.FirstOrDefault();
            ICollection<BlogPicture> blogPictures = _context.BlogPictures.ToList();
            return View(new HomeIndexViewModel 
            {AboutSection=aboutSection,InfoLists=infoLists,Categories=categories,
                Products=products,Subscribe=subscribe,ExpertImages=expertImages,
                ExpertSection=expertSection,Blog=blog, BlogPictures=blogPictures
            });
        }
    }
}
