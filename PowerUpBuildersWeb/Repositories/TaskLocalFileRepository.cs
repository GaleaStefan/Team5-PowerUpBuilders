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
    }
}
