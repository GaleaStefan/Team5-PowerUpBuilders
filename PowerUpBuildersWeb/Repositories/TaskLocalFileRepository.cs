using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public class TaskLocalFileRepository : ITaskLocalFileRepository
    {
        private readonly AppDbContext _context;

        public TaskLocalFileRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TaskLocalFile> GetTaskLocalFiles()
            => _context.TaskLocalFiles.ToList();

        public void AddFile(TaskLocalFile file)
        {
            _context.TaskLocalFiles.Add(file);
        }

        public void DeleteFile(int fileID)
        {
            TaskLocalFile file = _context.TaskLocalFiles.Find(fileID);
            _context.TaskLocalFiles.Remove(file);
        }

        public void DeleteFile(string fileName)
        {
            TaskLocalFile file = _context.TaskLocalFiles.Find(fileName);
            _context.TaskLocalFiles.Remove(file);
        }

        public IEnumerable<TaskLocalFile> GetByTaskID(int taskID)
            => _context.TaskLocalFiles.Where(file => file.Task.Id == taskID);

        public IEnumerable<TaskLocalFile> GetInTimeRange(DateTime start, DateTime end)
            => _context.TaskLocalFiles.Where(file => file.UploadDate >= start && file.UploadDate <= end);

        public void Save()
            => _context.SaveChanges();
    }
}
