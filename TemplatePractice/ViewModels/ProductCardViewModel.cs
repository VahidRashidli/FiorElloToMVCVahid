using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplatePractice.Models;

namespace TemplatePractice.ViewModels
{
    public class ProductCardViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; }
    }
}
