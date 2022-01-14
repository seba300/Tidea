using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Tidea.Core.Entities;

namespace Tidea.Web
{
    public class UploadFile
    {
        public UploadFile()
        {
            
        }
        public string UploadImage(IFormFile imageFile)
        {
            string fileName = null;
            string uploadDir = "wwwroot/CampaignsMedia";

            if (imageFile != null)
            {
                fileName = Guid.NewGuid().ToString() + "-" + imageFile.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                return fileName;
            }
            return String.Empty;
        }
    }
}