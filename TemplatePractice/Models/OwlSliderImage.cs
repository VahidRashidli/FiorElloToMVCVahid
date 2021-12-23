using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Models
{
    public class OwlSliderImage:BaseEntity
    {
            [
            MaxLength(1000, ErrorMessage = "The image name must have less than 200 characters")
            ]
        public string Image { get; set; }
        public OwlSlider slider { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
