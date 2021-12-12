using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class BlogPicture:BaseEntity
    {
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
