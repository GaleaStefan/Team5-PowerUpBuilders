using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.ViewModel;
using PowerUpBuildersWeb.WorkUnits;

namespace PowerUpBuildersWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectManager _projectManager;
        public ProjectController(
            IProjectManager manager)
        {
            _projectManager = manager;
        }

        public IActionResult Index(int id)
        {
            Project current = _projectManager.GetProject(id);

            if (current is null)
                return RedirectToAction("Index", "Home");
            
            ProjectViewModel project = new()
            {
                Project = current,
                Tasks = _projectManager.GetProjectTasks(current.Id),
                Employees = _projectManager.GetProjectAssignedEmployees(current.Id)
            };

            return View(project);
        }
    }
}
