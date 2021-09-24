using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.ViewModel
{
    public class TaskEditorViewModel
    {
        public Models.Task Task { get; set; }
        public IEnumerable<Employee> AssignedEmployees { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<string> ImagePaths { get; set; }

        public IEnumerable<string> FilePaths { get; set; }

    }
}
