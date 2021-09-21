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

        public void DeleteTask(int taskId)
        {
            Task task = _context.Tasks.Find(taskId);
            _context.Tasks.Remove(task);
        }

        public Task GetTaskByID(int taskId)
        {
            return _context.Tasks.Find(taskId);
        }

        public IEnumerable<Task> GetTasks()
            => _context.Tasks.ToList();

        public void InsertTask(Task task)
        {
            _context.Tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            _context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
