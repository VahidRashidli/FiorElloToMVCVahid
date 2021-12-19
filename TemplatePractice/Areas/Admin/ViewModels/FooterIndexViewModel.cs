using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplatePractice.Models;

namespace TemplatePractice.Areas.Admin.ViewModels
{
    public class FooterIndexViewModel
    {
        public Footer Footer { get; set; }
        public ICollection<FooterCategory> FooterCategories { get; set; }
        public ICollection<FooterCategorySection> FooterCategorySections { get; set; }
    }
}
