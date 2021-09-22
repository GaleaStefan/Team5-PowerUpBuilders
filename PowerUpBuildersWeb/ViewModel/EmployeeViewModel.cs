using PowerUpBuildersWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerUpBuildersWeb.ViewModel
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
