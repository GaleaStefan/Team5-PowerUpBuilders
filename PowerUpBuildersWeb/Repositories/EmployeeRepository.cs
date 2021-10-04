using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            => _appDbContext.Employees.Include(e => e.Tasks).ToList();

        public void DeleteEmployee(int? employeeId)
        {
            Employee employee = _appDbContext.Employees.Find(employeeId);
            _appDbContext.Employees.Remove(employee);
        }

        public Employee GetEmployeeById(int? employeeId) 
            => _appDbContext.Employees.Find(employeeId);

        public void InsertEmployee(Employee employee) 
            => _appDbContext.Employees.Add(employee);

        public void UpdateEmployee(Employee employee) 
            => _appDbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        public void Save() 
            => _appDbContext.SaveChanges();
    }
}
