using System;
using Microsoft.AspNetCore.Http;

namespace PowerUpBuildersWeb.Services
{
    public interface IUploadsManager
    {
        public string UploadsPath { get; }
        void UploadFile(IFormFile file, string seed);

        void DeleteFile(string fileName);
    }
}