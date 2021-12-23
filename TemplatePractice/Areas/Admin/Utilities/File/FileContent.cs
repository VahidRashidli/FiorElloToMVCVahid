using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Areas.Admin.Utilities.File
{
    public static class FileContent
    {
        public static bool CheckContent(this IFormFile file,string type) 
        {
            if (!file.ContentType.Contains(type))
            {
                return false;
            }
            return true;
        }
    }
}
