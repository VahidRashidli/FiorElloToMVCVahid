using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class SaySection:BaseEntity
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public string PersonName { get; set; }
        public string Profession { get; set; }
    }
}
