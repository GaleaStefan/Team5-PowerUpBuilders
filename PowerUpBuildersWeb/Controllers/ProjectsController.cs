using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.ViewModel;
using System;


namespace PowerUpBuildersWeb.Controllers
{
    public class ProjectsController : Controller
    {

        private readonly IProjectRepository _projectRepository;
        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public IActionResult Index()
        {
            var projects = _projectRepository.GetProjects();
            var projectsViewModel = new ProjectsViewModel
            {
                Projects = projects
            };
            return View(projectsViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectRepository.InsertProject(project);
                _projectRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            return PartialView("_UpdateProject",project);
        }


        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectRepository.UpdateProject(project);
                _projectRepository.Save();
                return RedirectToAction("Index");
            }else
            {
                return PartialView("_UpdateProject", project);
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            return PartialView("_DeleteProject",project);
        }
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _projectRepository.DeleteProject(id);
            _projectRepository.Save();
            return RedirectToAction("Index", "Projects");
        }
        public ActionResult Details(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            return PartialView("_ProjectDetails", project);
        }
       
    }
}
