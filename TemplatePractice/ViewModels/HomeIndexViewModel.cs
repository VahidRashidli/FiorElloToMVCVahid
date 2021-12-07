using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplatePractice.Models;

namespace TemplatePractice.ViewModels
{
    public class HomeIndexViewModel
    {
        public AboutSection AboutSection { get; set; }
        public ICollection<InfoList> InfoLists { get; set; }
    }
}
