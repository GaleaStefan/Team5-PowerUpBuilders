using System;
using System.Collections.Generic;
using System.Linq;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetProjectTasks(int projectId);
        Task GetTaskByID(int taskId);

        string GetTaskNumber(DateTime date);
        void InsertTask(Task task);
        void DeleteTask(int taskId);
        void UpdateTask(Task task);
        void Save();
    }
}
