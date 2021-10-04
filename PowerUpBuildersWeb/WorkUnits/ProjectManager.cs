using System;
using System.Collections.Generic;
using System.Linq;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;

namespace PowerUpBuildersWeb.WorkUnits
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IEmployeeTaskRepository _employeeTaskRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ITaskRepository _taskRepo;
        private readonly IFilesManager _filesManager;

        public IProjectRepository ProjectRepo => _projectRepo;
        public IEmployeeTaskRepository EmployeeTaskRepo => _employeeTaskRepo;
        public IEmployeeRepository EmployeeRepo => _employeeRepo;
        public ITaskRepository TaskRepo => _taskRepo;
        public IFilesManager FilesManager => _filesManager;

        public ProjectManager(
            IProjectRepository projectRepo,
            IEmployeeTaskRepository employeeTaskRepo,
            IEmployeeRepository employeeRepo,
            ITaskRepository taskRepo,
            IFilesManager filesManager)
        {
            _projectRepo = projectRepo;
            _employeeTaskRepo = employeeTaskRepo;
            _employeeRepo = employeeRepo;
            _taskRepo = taskRepo;
            _filesManager = filesManager;
        }

        public IEnumerable<Employee> GetProjectAssignedEmployees(int projectId)
        {
            var tasksIds = TaskRepo.GetProjectTasks(projectId).Select(task => task.Id);

            var employeesIds = EmployeeTaskRepo
                .GetAllLinks()
                .Where(link => tasksIds.Contains(link.TaskId))
                .Select(link => link.EmployeeId)
                .Distinct();

            return EmployeeRepo.GetEmployees().Where(employee => employeesIds.Contains(employee.Id));
        }

        public IEnumerable<Employee> GetTaskAssignedEmployees(int taskId)
        {
            var employeeIds = EmployeeTaskRepo.GetTaskLinks(taskId).Select(link => link.EmployeeId);

            return EmployeeRepo.GetEmployees().Where(employee => employeeIds.Contains(employee.Id));
        }
    }
}
