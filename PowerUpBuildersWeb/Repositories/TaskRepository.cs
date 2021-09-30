using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public string GetTaskNumber(DateTime now)
        {
            string strDate = now.ToString("yyyyMMdd");
            int previous = _context.Tasks.Where(task => task.TaskNumber.Contains("TK" + strDate)).Count();
            string currentCount = (previous + 1).ToString("00");

            return $"TK{strDate}_{currentCount}";
        }

        public void DeleteTask(int taskId)
        {
            Task task = _context.Tasks.Find(taskId);
            _context.Tasks.Remove(task);
        }

        public Task GetTaskByID(int taskId)
            => _context.Tasks
            .Where(t => t.Id == taskId)
            .Include(t => t.Files)
            .Include(t => t.Employees)
            .First();

        public IEnumerable<Task> GetTasks()
            => _context.Tasks.ToList();

        public void InsertTask(Task task)
        {
            task.TaskNumber = GetTaskNumber(DateTime.Now);
            _context.Tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            var old = _context.Tasks.Where(t => t.Id == task.Id).First();
            _context.Entry(old).CurrentValues.SetValues(task);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Task> GetProjectTasks(int projectId)
            => _context.Tasks.Where(task => task.ProjectId == projectId);
    }
}
