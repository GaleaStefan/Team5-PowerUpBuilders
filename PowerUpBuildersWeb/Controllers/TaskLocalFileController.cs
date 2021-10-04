using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using PowerUpBuildersWeb.WorkUnits;

namespace PowerUpBuildersWeb.Controllers
{
    public class TaskLocalFileController : Controller
    {
        private readonly IFilesManager _filesManager;

        public TaskLocalFileController(IFilesManager filesManager)
        {
            _filesManager = filesManager;
        }

        [HttpGet("/api/taskFiles/")]
        public string GetTaskFilePaths(int taskId)
        {
            var serialized = JsonConvert.SerializeObject(_filesManager.GetFiles(taskId));
            return serialized;
        }

        [HttpPost("/api/taskFiles/delete")]
        public void DeleteFile(string file)
            => _filesManager.DeleteFile(file);

        [HttpGet("/api/taskFiles/file")]
        public FileResult GetFile(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out string contentType))
            {
                contentType = "application/octet-stream";
            }

            string path = _filesManager.GetUploadsPath() + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, contentType, fileName);
        }
    }
}
