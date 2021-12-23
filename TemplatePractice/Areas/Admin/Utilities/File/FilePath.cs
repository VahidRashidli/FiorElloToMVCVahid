using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Areas.Admin.Utilities.File
{
    public static class FilePath
    {
       

        public static string GetPath(string folderName,IFormFile file,Guid guid) 
        {
            return Path.Combine(folderName, guid+file.FileName);
        }
    }
}
