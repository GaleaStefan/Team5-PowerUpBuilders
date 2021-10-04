using System.Collections.Generic;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public interface IEmployeeTaskRepository
    {
        void AssignEmployeeToTask(EmployeeTask link);
        void RemoveEmployeeFromTask(int employeeId, int taskId);
        void UpdateLink(EmployeeTask link);
        IEnumerable<EmployeeTask> GetTaskLinks(int taskId);
        IEnumerable<EmployeeTask> GetAllLinks();

        void RemoveTaskLinks(int taksId);
        void SaveChanges();
    }
}
