using System.Collections.Generic;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.ViewModel
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
