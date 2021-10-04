using System.Collections.Generic;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.ViewModel
{
    public class ProjectsViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public Project project { get; set; }
    }
}
