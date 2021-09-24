using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace PowerUpBuildersWeb.Services
{
    public class UploadsManager : IUploadsManager
    {
        private readonly string _uploadsPath;

        public string UploadsPath { get => _uploadsPath; }

        public UploadsManager(IConfiguration config)
        {
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

        public void UploadFile(IFormFile file, string seed)
        {
            var uniqueFileName = seed + "_" + file.FileName;
            var path = Path.Combine(_uploadsPath, uniqueFileName);
            file.CopyToAsync(new FileStream(path, FileMode.Create));
        }
    }
}