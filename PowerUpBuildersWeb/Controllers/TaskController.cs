using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.ViewModel;
using PowerUpBuildersWeb.WorkUnits;

namespace PowerUpBuildersWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly IProjectManager _projectManager;
        public TaskController(IProjectManager repo)
            => _projectManager = repo;

        [HttpPost]
        public string Delete(int id)
        {
            Console.WriteLine(id);
            return "/Home/Index/";
        }

        [HttpGet]
        public IActionResult Create(int projectId)
            => PartialView("_TaskModal", new TaskEditorViewModel() {ProjectId = projectId, Employees = _projectManager.EmployeeRepo.GetEmployees(), ModalMode = ModalMode.Edit });

        [HttpPost]
        public IActionResult Details(int projectId, int ID)
        {
            TaskEditorViewModel model = new()
            {
                ProjectId = projectId,
                Task = _projectManager.TaskRepo.GetTaskByID(ID),
                LinkedEmployees = _projectManager.EmployeeTaskRepo.GetTaskLinks(ID).Select(link=>link.Id),
                Employees = _projectManager.EmployeeRepo.GetEmployees(),
                //ImagePaths = _projectManager.FilesManager.Get(ID),
                //FilePaths = _projectManager.GetTaskFiles(ID),
                ModalMode = ModalMode.ViewEdit
            };

            if(model is null)
                RedirectToAction("Index", "Home");

            return PartialView("_TaskModal", model);
        }
    }
}
