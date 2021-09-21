using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int employeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
