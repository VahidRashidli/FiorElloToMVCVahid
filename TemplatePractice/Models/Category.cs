using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
