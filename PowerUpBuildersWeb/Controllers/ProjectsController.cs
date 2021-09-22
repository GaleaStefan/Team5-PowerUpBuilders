using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            ProjectsViewModel _projectsViewModel = new ProjectsViewModel() { Projects = _projectRepository.GetProjects() };
            return View(_projectsViewModel);        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult DeleteProject(int id)
        {
            var selectedProject = _projectRepository.GetProjects().FirstOrDefault(p => p.Id == id);
            if(selectedProject!=null)
            {
                _projectRepository.DeleteProject(id);
                _projectRepository.Save();
            }

            return RedirectToAction("Index");
        }
    }
}
