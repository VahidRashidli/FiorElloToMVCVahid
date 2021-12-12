using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class FooterCategory:BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public ICollection<FooterCategorySection> footerCategorySections { get; set; }
    }
}
