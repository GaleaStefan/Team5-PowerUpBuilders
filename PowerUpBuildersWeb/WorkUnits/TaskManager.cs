using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;

namespace PowerUpBuildersWeb.WorkUnits
{
    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepository _tasks;
        private readonly IEmployeeRepository _employees;
        private readonly IEmployeeTaskRepository _links;
        private readonly IFilesManager _files;

        public TaskManager(ITaskRepository tasks, IEmployeeRepository employees, IEmployeeTaskRepository links, IFilesManager files)
        {
            _tasks = tasks;
            _employees = employees;
            _links = links;
            _files = files;
        }

        public IEnumerable<Employee> GetAllEmployees()
            => _employees.GetEmployees();

        public Models.Task GetTask(int taskId)
            => _tasks.GetTaskByID(taskId);

        public IEnumerable<Employee> GetTaskAssignedEmployees(int taskId)
        {
            var employeeIds = _links.GetTaskLinks(taskId).Select(link => link.EmployeeId);

            return _employees.GetEmployees().Where(employee => employeeIds.Contains(employee.Id));
        }

        public IEnumerable<string> GetTaskFiles(int taskId)
            => _files.GetFiles(taskId, FileType.File);

        public IEnumerable<string> GetTaskPhotos(int taskId)
            => _files.GetFiles(taskId, FileType.Photo);
    }
}
