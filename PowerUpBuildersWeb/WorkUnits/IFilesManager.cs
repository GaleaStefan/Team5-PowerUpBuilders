using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.WorkUnits
{
    public interface IFilesManager
    {
        void AddFile(IFormFile file, DateTime timeStamp, FileType fileType, Task task);
        void DeleteFile(string name);
        void DeleteTaskFiles(int taskId);

        void DeleteFilesInTimeRange(DateTime start, DateTime end);
    }
}
