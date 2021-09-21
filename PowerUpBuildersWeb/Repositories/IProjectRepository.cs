using System.Collections.Generic;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
    }
}