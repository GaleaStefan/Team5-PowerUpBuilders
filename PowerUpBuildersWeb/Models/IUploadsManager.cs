using System;
using Microsoft.AspNetCore.Http;

namespace PowerUpBuildersWeb.Models
{
    public interface IUploadsManager
    {
        void UploadFile(IFormFile file, DateTime timeStamp);
        void DeleteFile(string fileName);
        void DeleteFiles(string[] fileNames);
    }
}