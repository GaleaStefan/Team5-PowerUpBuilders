using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;
using PowerUpBuildersWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerUpBuildersWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            EmployeeViewModel employees = new EmployeeViewModel();
            employees.Employees = _employeeRepository.GetEmployees();
            return View(employees);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Tasks")] Employee employee)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.UpdateEmployee(employee);
                    _employeeRepository.Save();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_employeeRepository.GetEmployees().Contains(employee))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public RedirectToActionResult Delete(int employeeId)
        {
            var employee = _employeeRepository.GetEmployees().FirstOrDefault(e => e.Id == employeeId);

            if(employee != null)
            {
                _employeeRepository.DeleteEmployee(employeeId);
            }
            return RedirectToAction("Index");
        }
    }
}
