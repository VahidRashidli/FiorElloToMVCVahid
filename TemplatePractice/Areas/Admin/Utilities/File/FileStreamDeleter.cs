using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Areas.Admin.Utilities.File
{
    public static class FileStreamDeleter
    {
        public  static void DeleteFileStream( string folderName,string name)
        {
            string path=Path.Combine(folderName,name);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
