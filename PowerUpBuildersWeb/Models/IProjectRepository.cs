using System.Collections.Generic;

namespace PowerUpBuildersWeb.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
    }
}