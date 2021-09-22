using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ProjectManager(
            IProjectRepository projectRepo, 
            IEmployeeTaskRepository employeeTaskRepo, 
            IEmployeeRepository employeeRepo, 
            ITaskRepository taskRepo)
        {
            _projectRepo = projectRepo;
            _employeeTaskRepo = employeeTaskRepo;
            _employeeRepo = employeeRepo;
            _taskRepo = taskRepo;
        }

        public IEnumerable<Employee> GetProjectAssignedEmployees(int projectId)
        {
            var tasksIds = _taskRepo.GetTasks()
                .Where(task => task.ProjectId == projectId)
                .Select(task => task.Id);

            var employeesIds = _employeeTaskRepo.GetAllLinks()
                .Where(link => tasksIds.Contains(link.TaskId))
                .GroupBy(link => link.EmployeeId)
                .Select(group => group.First().Id);

            return _employeeRepo.GetEmployees().Where(employee => employeesIds.Contains(employee.Id));
        }

        public IEnumerable<Models.Task> GetProjectTasks(int projectId)
            => _taskRepo.GetProjectTasks(projectId);

        public Project GetProject(int id)
            => _projectRepo.GetProjectById(id);
    }
}
