using System.Collections.Generic;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;

namespace PowerUpBuildersWeb.WorkUnits
{
    public interface IProjectManager
    {
        public IProjectRepository ProjectRepo { get; }
        public IEmployeeTaskRepository EmployeeTaskRepo { get; }
        public IEmployeeRepository EmployeeRepo { get; }
        public ITaskRepository TaskRepo { get; }
        public IFilesManager FilesManager { get; }

        IEnumerable<Employee> GetProjectAssignedEmployees(int projectId);

        public IEnumerable<Employee> GetTaskAssignedEmployees(int taskId);
    }
}
