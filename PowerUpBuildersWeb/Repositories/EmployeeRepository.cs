using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _appDbContext.Employees.ToList();
        }
    }
}
