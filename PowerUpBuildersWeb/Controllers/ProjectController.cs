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
            Project current = _projectManager.ProjectRepo.GetProjectById(id);

            if (current is null)
                return RedirectToAction("Index", "Home");
            
            ProjectViewModel project = new()
            {
                Project = current,
                Tasks = _projectManager.TaskRepo.GetProjectTasks(current.Id),
                Employees = _projectManager.GetProjectAssignedEmployees(current.Id)
            };

            return View(project);
        }

        [HttpPost]
        public void UpdateTask(TaskEditorViewModel data)
        {
            if(!ModelState.IsValid)
            {
                return;
            }

            if(data.Task.Id == 0) // New
            {
                _projectManager.TaskRepo.InsertTask(data.Task);
            }
            else
            {
                _projectManager.TaskRepo.UpdateTask(data.Task);
            }

            _projectManager.TaskRepo.Save();

            foreach (var file in data.Uploads)
            {
                FileType fileType = GetFileType(file);
                _projectManager.FilesManager.AddFile(file, DateTime.Now, fileType, _projectManager.TaskRepo.GetTaskByID(data.Task.Id));
            } 
        }

        private FileType GetFileType(IFormFile file)
        {
            string extension = System.IO.Path.GetExtension(file.FileName);
            FileType fileType = _imgExtensions.Contains(extension.ToLower()) ? FileType.Photo : FileType.File;
            return fileType;
        }
    }
}
