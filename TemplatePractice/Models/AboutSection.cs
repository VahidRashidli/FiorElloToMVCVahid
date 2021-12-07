using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class AboutSection
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
