using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Models
{
    public class OwlSlider:BaseEntity
    {
            [
            Required(ErrorMessage ="The owl slider must have a title"),
            MaxLength(1000,ErrorMessage = "The title must have less than 50 chars")
            ]
        public string Title { get; set; }

            [
            Required(ErrorMessage = "The owl slider must have a description"),
           MaxLength(1000, ErrorMessage = "The description must have less than 100 chars")
            ]
        public string Description { get; set; }

           [
            
           MaxLength(1000, ErrorMessage = "The image name must have less than 200 characters")
           ]
        public string Image { get; set; }
        public ICollection<OwlSliderImage> Images { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
