using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplatePractice.Models;

namespace TemplatePractice.ViewModels
{
    public class InstagramSectionViewModel
    {
        public InstagramSection InstagramSection { get; set; }
        public ICollection<InstagramSectionPicture> InstagramSectionPictures { get; set; }

    }
}
