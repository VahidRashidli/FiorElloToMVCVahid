using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Areas.Admin.Utilities.File
{
    public static class FileSize
    {
        public static bool CheckFileSizeForGB(this IFormFile file)
        {
            if (file.Length>1024*1000)
            {
                return false;
            }
            return true;
        }
    }
}
