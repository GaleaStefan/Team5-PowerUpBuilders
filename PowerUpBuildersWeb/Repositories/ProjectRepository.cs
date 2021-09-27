using System;
using System.Collections.Generic;
using System.Linq;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        
        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteProject(int projectId)
        {
            Project project = _context.Projects.Find(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }
        }

        public Project GetProjectById(int projectId)
        {
            return _context.Projects.Find(projectId);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public void InsertProject(Project project)
        {
            _context.Projects.Add(project);
            Save();
        }

        public void UpdateProject(Project project)
        {
            _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}