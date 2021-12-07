using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; }
    }
}
