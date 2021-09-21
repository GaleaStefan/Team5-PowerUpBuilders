using System;
using System.Collections.Generic;
using System.Linq;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetTasks()
            => _context.Tasks.ToList();
    }
}
