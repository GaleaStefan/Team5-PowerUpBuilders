using System.Collections.Generic;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int projectId);

        Project GetProjectWithTasks(int projectId);

        void InsertProject(Project project);
        void DeleteProject(int projectId);
        void UpdateProject(Project project);
        void Save();
    }
}