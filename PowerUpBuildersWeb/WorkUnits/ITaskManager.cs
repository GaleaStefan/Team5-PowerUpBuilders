using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.WorkUnits
{
    public interface ITaskManager
    {
        Models.Task GetTask(int taskId);
        IEnumerable<Employee> GetTaskAssignedEmployees(int taskId);

        IEnumerable<Employee> GetAllEmployees();

        IEnumerable<string> GetTaskPhotos(int taskId);
        IEnumerable<string> GetTaskFiles(int taskId);
    }
}
