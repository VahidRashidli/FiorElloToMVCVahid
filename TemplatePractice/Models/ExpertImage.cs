using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Models
{
    public class ExpertImage:BaseEntity
    {
        public string ImageName { get; set; }
        public string PersonName { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string Profession { get; set; }
        public int Order { get; set; }
    }
}
