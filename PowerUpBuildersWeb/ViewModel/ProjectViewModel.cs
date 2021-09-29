using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerUpBuildersWeb.ViewModel
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        //public IEnumerable<Models.Task> Tasks { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        //public IEmployeeTaskRepository TaskEmployees { get; set; }
    }
}
