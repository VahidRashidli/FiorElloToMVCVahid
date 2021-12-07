using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class ExpertImage:BaseEntity
    {
        public string ImageName { get; set; }
        public string PersonName { get; set; }
        public string Profession { get; set; }
        public int Order { get; set; }
    }
}
