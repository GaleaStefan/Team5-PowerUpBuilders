using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.ViewModel;

namespace PowerUpBuildersWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IEmployeeTaskRepository _employeeTaskRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ITaskRepository _taskRepo;
        public ProjectController(
            IProjectRepository projectRepository, 
            IEmployeeRepository employeeRepository, 
            IEmployeeTaskRepository employeeTaskRepo,
            ITaskRepository taskRepository)
        {
            _projectRepo = projectRepository;
            _employeeTaskRepo = employeeTaskRepo;
            _employeeRepo = employeeRepository;
            _taskRepo = taskRepository;
        }

        public IActionResult Index(int id)
        {
            Project current = _projectRepo.GetProjectById(id);

            if (current is null)
                return RedirectToAction("Index", "Home");
            
            ProjectViewModel project = new()
            {
                Project = current,
                Tasks = _taskRepo.GetProjectTasks(id),
                Employees = _employeeRepo.GetEmployees()
            };

            return View(project);
        }
    }
}
