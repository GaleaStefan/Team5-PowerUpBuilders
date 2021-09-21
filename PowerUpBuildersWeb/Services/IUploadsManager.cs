using System;
using Microsoft.AspNetCore.Http;

namespace PowerUpBuildersWeb.Services
{
    public interface IUploadsManager
    {
        void UploadFile(IFormFile file, string seed);
        void DeleteFile(string fileName);
    }
}