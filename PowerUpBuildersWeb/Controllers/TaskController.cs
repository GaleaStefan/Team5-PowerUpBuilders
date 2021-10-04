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
        public void Delete(int id)
        {
            _projectManager.EmployeeTaskRepo.RemoveTaskLinks(id);
            _projectManager.EmployeeTaskRepo.SaveChanges();
            _projectManager.FilesManager.DeleteTaskFiles(id);
            _projectManager.TaskRepo.DeleteTask(id);
            _projectManager.TaskRepo.Save();
        }

        [HttpGet]
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
