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

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }
    }
}