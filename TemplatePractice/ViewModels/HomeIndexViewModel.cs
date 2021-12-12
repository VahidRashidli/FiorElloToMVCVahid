using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplatePractice.Models;

namespace TemplatePractice.ViewModels
{
    public class HomeIndexViewModel
    {
        public AboutSection AboutSection { get; set; }
        public ICollection<InfoList> InfoLists { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Subscribe Subscribe { get; set; }
        public ExpertSection ExpertSection { get; set; }
        public ICollection<ExpertImage> ExpertImages { get; set; }
        public Blog Blog { get; set; }
        public ICollection<BlogPicture> BlogPictures { get; set; }
    }
}
