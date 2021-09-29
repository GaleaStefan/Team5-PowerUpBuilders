using System;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Details(int projectId, int taskId)
        {
            TaskModalViewModel model = new()
            {
                Task = taskId > 0 ? _projectManager.TaskRepo.GetTaskByID(taskId) : new Models.Task() { ProjectId = projectId },
                ModalMode = taskId > 0 ? ModalMode.ViewEdit : ModalMode.Edit
            };

            if(model is null)
                RedirectToAction("Index", "Home");

            return PartialView("_TaskModal", model);
        }
    }
}
