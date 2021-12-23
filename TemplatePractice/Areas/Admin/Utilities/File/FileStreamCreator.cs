using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TemplatePractice.Areas.Admin.Utilities.File
{
    public static class FileStreamCreator
    {
        public  async static Task CreateFileStream(string folderName,IFormFile file,Guid guid)
        {
            FileStream fileStream = new FileStream(FilePath.GetPath(folderName,file,guid),FileMode.Create);
            await file.CopyToAsync(fileStream);
            fileStream.Close();
        }
    }
}
