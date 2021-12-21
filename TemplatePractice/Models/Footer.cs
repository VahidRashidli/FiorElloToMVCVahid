using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class Footer:BaseEntity
    {

        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string Image { get; set; }

       
    }
}
