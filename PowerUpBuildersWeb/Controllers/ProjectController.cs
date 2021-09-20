using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.ViewModel;

namespace PowerUpBuildersWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository repository;
        public ProjectController(IProjectRepository projectRepository)
        {
            repository = projectRepository;
        }

        public IActionResult Index()
        {
            ProjectViewModel _projectViewModel = new ProjectViewModel() {Projects=repository.GetProjects() };
            return View(_projectViewModel);
        }
    }
}
