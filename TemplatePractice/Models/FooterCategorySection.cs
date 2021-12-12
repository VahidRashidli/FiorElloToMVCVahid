using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class FooterCategorySection:BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public FooterCategory FooterCategory { get; set; }
        public string Link { get; set; }
    }
}
