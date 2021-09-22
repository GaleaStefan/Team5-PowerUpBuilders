using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.WorkUnits
{
    public interface IProjectManager
    {
        IEnumerable<Employee> GetProjectAssignedEmployees(int projectId);
        IEnumerable<Models.Task> GetProjectTasks(int projectId);
        Project GetProject(int id);
    }
}
