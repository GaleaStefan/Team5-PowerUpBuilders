using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public void UpdateTask(TaskModalEditVM data)
        {
            data.ToString();
        }

        private FileType GetFileType(IFormFile file)
        {
            string extension = System.IO.Path.GetExtension(file.FileName);
            FileType fileType = _imgExtensions.Contains(extension.ToLower()) ? FileType.Photo : FileType.File;
            return fileType;
        }
    }
}
