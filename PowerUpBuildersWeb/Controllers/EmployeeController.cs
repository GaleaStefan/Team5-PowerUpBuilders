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


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.GetEmployeeById(id);
            //var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Tasks")] Employee employee)
        {
            if(id != employee.Id)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.GetEmployeeById(id);
            //var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            if(employee != null)
            {
                _employeeRepository.DeleteEmployee(id);
                _employeeRepository.Save();
            }
            else
            {
                return NotFound();
            }


            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee([Bind("Id,Name")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.InsertEmployee(employee);
                _employeeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
    }
}
