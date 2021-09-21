using System;
using System.Collections.Generic;
using System.Linq;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
    }
}
