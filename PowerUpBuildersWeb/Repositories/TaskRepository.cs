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

        public string GetTaskNumber()
        {
            DateTime now = DateTime.Now;
            string strDate = now.ToString("YYYYMMdd");
            int dailyCount = 0;
            string taskNumber = "";

            for(int i = 0; i < _context.Tasks.Count(); i++)
            {
                if (dailyCount < 10)
                {
                    taskNumber =  "TK" + strDate + "0" + dailyCount.ToString();
                }
                else
                {
                    taskNumber = "TK" + strDate + dailyCount.ToString();
                }
                dailyCount++;
            }

            return taskNumber;
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
            task.TaskNumber = GetTaskNumber();
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

        public IEnumerable<Task> GetProjectTasks(int projectId)
            => _context.Tasks.Where(task => task.ProjectId == projectId);
    }
}
