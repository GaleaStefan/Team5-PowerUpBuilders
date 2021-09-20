using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Models;

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
            return View(repository.GetProjects());
        }
    }
}
