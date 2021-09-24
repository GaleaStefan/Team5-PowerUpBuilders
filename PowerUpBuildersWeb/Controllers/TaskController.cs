using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.ViewModel;
using PowerUpBuildersWeb.WorkUnits;

namespace PowerUpBuildersWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager _taskManager;
        public TaskController(ITaskManager repo)
            => _taskManager = repo;

        [HttpPost]
        public void Update(Task task)
        {

        }

        [HttpPost]
        public string Delete(int id)
        {
            Console.WriteLine(id);
            return "/Home/Index/";
        }

        [HttpGet]
        public IActionResult Create()
            => PartialView("_TaskModal", new TaskEditorViewModel() { ModalMode = ModalMode.Edit });

        [HttpPost]
        public IActionResult Details(int ID)
        {
            TaskEditorViewModel model = new()
            {
                Task = _taskManager.GetTask(ID),
                AssignedEmployees = _taskManager.GetTaskAssignedEmployees(ID),
                Employees = _taskManager.GetAllEmployees(),
                ImagePaths = _taskManager.GetTaskPhotos(ID),
                FilePaths = _taskManager.GetTaskFiles(ID),
                ModalMode = ModalMode.ViewEdit
            };

            if(model is null)
                RedirectToAction("Index", "Home");

            return PartialView("_TaskModal", model);
        }
    }
}
