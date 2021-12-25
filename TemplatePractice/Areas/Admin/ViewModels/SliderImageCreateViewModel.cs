using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Areas.Admin.ViewModels
{
    public class SliderImageCreateViewModel
    {
        public IFormFile[] Files  { get; set; }
    }
}
