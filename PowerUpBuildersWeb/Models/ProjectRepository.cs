using System.Collections.Generic;
using System.Linq;

namespace PowerUpBuildersWeb.Models
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