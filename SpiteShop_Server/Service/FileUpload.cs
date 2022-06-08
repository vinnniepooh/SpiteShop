using Microsoft.AspNetCore.Components.Forms;
using SpiteShop_Server.Service.IService;
using System.IO;

namespace SpiteShop_Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
          _webHostEnvironment  = webHostEnvironment;
        }
        public bool DeleteFile(string filePath)
        {
            if (File.Exists(_webHostEnvironment.WebRootPath+filePath))
            {
                File.Delete(_webHostEnvironment.WebRootPath + filePath);
                return true;
            }
            return false;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new(file.Name); //Filename wird erstellt
            var fileName = Guid.NewGuid().ToString()+fileInfo.Extension; // neue guid in string datentyp wird erstellt und mit dem filenamen kombiniert
            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\product"; //directory wird erstellt im Product ordner
            if (!Directory.Exists(folderDirectory)) // schaut ob die directory existiert
            {
                Directory.CreateDirectory(folderDirectory); //Directory wird erstellt
            }
            var filePath = Path.Combine(folderDirectory, fileName); //Directory wird kombiniert mit dem filename 

            await using FileStream fs = new FileStream(filePath, FileMode.Create); 
            await file.OpenReadStream().CopyToAsync(fs);

            var fullPath = $"/images/product/{fileName}";
            return fullPath;

        }
    }
}
