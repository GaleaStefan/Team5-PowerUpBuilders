using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.Services;

namespace PowerUpBuildersWeb.WorkUnits
{
    public class FilesManager : IFilesManager
    {
        private readonly IUploadsManager _uploadsManager;
        private readonly ITaskLocalFileRepository _filesRep;

        public FilesManager(IUploadsManager uploadsManager, ITaskLocalFileRepository filesRepository)
        {
            _uploadsManager = uploadsManager;
            _filesRep = filesRepository;
        }

        public void AddFile(IFormFile formFile, DateTime timeStamp, FileType fileType, Models.Task task)
        {
            string time = timeStamp.ToString("yyyyMMddHHmmssfff");

            TaskLocalFile file = new()
            {
                FileName = time + "_" + formFile.FileName,
                FileType = fileType,
                UploadDate = timeStamp,
                Task = task
            };

            _filesRep.AddFile(file);
            _filesRep.Save();
            _uploadsManager.UploadFile(formFile, time);
        }

        public void DeleteFile(string name)
        {
            _filesRep.DeleteFile(name);
            _filesRep.Save();
            _uploadsManager.DeleteFile(name);
        }

        public void DeleteFilesInTimeRange(DateTime start, DateTime end)
        {
            foreach (TaskLocalFile file in _filesRep.GetInTimeRange(start, end))
            {
                _uploadsManager.DeleteFile(file.FileName);
                _filesRep.DeleteFile(file.Id);
            }
            _filesRep.Save();
        }

        public void DeleteTaskFiles(int taskId)
        {
            foreach (TaskLocalFile file in _filesRep.GetByTaskID(taskId))
            {
                _uploadsManager.DeleteFile(file.FileName);
                _filesRep.DeleteFile(file.Id);
            }
            _filesRep.Save();
        }

        public IEnumerable<TaskFile> GetFiles(int taskId)
        {
            List<TaskFile> files = new();
            var localFiles = _filesRep.GetByTaskID(taskId);

            foreach (var localFile in localFiles)
            {
                files.Add(new()
                {
                    Path = _uploadsManager.UploadsPath,
                    Name = localFile.FileName,
                    NameSimplified = localFile.FileName.Substring(localFile.FileName.IndexOf("_") + 1),
                    Type = localFile.FileType
                });
            }

            return files;
        }

        public string GetUploadsPath()
            => _uploadsManager.UploadsPath;
    }
}
