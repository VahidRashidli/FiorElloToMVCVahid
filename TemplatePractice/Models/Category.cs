using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage ="The name is required"),MaxLength(20)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        public int Order { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
