using System.Collections.Generic;
using System.Linq;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly AppDbContext _context;

        public EmployeeTaskRepository(AppDbContext context)
            => _context = context;

        public void AssignEmployeeToTask(EmployeeTask link)
            => _context.EmployeesTasks.Add(link);

        public IEnumerable<EmployeeTask> GetAllLinks()
            => _context.EmployeesTasks.ToList();

        public IEnumerable<EmployeeTask> GetTaskLinks(int taskId)
            => _context.EmployeesTasks.Where(link => link.TaskId == taskId);

        public void RemoveEmployeeFromTask(int employeeId, int taskId)
        {
#nullable enable
            EmployeeTask? employeeTask = _context.EmployeesTasks.FirstOrDefault(link => link.EmployeeId == employeeId && link.TaskId == taskId);
#nullable disable

            if (employeeTask is not null)
                _context.EmployeesTasks.Remove(employeeTask);
        }

        public void SaveChanges()
            => _context.SaveChanges();
    }
}