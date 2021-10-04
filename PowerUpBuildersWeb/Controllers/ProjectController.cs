using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.ViewModel;
using PowerUpBuildersWeb.WorkUnits;

namespace PowerUpBuildersWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectManager _projectManager;

        private static readonly List<string> _imgExtensions = new()
        {
            ".png",
            ".jpg",
            ".jpeg",
            ".gif"
        };

        public ProjectController(
            IProjectManager manager)
        {
            _projectManager = manager;
        }

        public IActionResult Index(int id)
        {
            Project current = _projectManager.ProjectRepo.GetProjectWithTasks(id);

            if (current is null)
                return RedirectToAction("Index", "Home");

            ProjectViewModel project = new()
            {
                Project = current,
                Employees = _projectManager.GetProjectAssignedEmployees(current.Id)
            };

            return View(project);
        }

        [HttpPost]
        public IActionResult TaskEditor(TaskModalEditVM data)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_TaskModalEdit", data);
            }

            if (data.Task.Id == 0)
                _projectManager.TaskRepo.InsertTask(data.Task);
            else
                _projectManager.TaskRepo.UpdateTask(data.Task);

            _projectManager.TaskRepo.Save();
            UploadFiles(Request.Form.Files, data.Task);

            return new EmptyResult();
        }

        private void UploadFiles(IEnumerable<IFormFile> files, Task task)
        {
            foreach (var file in files)
            {
                _projectManager.FilesManager.AddFile(file, DateTime.Now, GetFileType(file), task);
            }
        }

        private static FileType GetFileType(IFormFile file)
        {
            string extension = System.IO.Path.GetExtension(file.FileName);
            FileType fileType = _imgExtensions.Contains(extension.ToLower()) ? FileType.Photo : FileType.File;
            return fileType;
        }
    }
}
