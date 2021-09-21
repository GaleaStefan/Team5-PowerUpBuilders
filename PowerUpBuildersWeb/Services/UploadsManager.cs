using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace PowerUpBuildersWeb.Services
{
    public class UploadsManager : IUploadsManager
    {
        private readonly IWebHostEnvironment _environment;
        private string _uploadsPath;

        public UploadsManager(IConfiguration config, IWebHostEnvironment environment)
        {
            _environment = environment;
            _uploadsPath = config["UploadsPath"];
        }

        public void DeleteFile(string name)
        {
            FileInfo file = new(_uploadsPath + name);

            if(file.Exists)
            {
                file.Delete();
            }
        }

        public void DeleteFiles(string[] names)
            => Array.ForEach(names, name => DeleteFile(name));

        public void UploadFile(IFormFile file, DateTime timeStamp)
        {
            var uniqueFileName = timeStamp.ToString("yyyyMMddHHmmss") + "_" + file.FileName;
            var path = Path.Combine(_uploadsPath, uniqueFileName);
            file.CopyToAsync(new FileStream(path, FileMode.Create));
        }
    }
}