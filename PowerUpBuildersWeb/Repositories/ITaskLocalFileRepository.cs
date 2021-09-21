using System;
using System.Collections.Generic;
using System.Linq;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public interface ITaskLocalFileRepository
    {
        IEnumerable<TaskLocalFile> GetTaskLocalFiles();
        void AddFile(TaskLocalFile file);

        void DeleteFile(int fileID);

        void DeleteFile(string fileName);

        IEnumerable<TaskLocalFile> GetByTaskID(int taskID);
        IEnumerable<TaskLocalFile> GetInTimeRange(DateTime start, DateTime end);

        void Save();
    }
}
