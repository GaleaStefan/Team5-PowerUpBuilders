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

        //private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            //_context = context;
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
                return RedirectToAction("Index");
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
        public IActionResult DeleteConfirmed(int employeeId)
        {
            var employee = _employeeRepository.GetEmployees().FirstOrDefault(e => e.Id == employeeId);

            if(employee != null)
            {
                _employeeRepository.DeleteEmployee(employeeId);
                _employeeRepository.Save();
            }

            return RedirectToAction("Index");
        }
    }
}
