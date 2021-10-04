using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Models;
using PowerUpBuildersWeb.Repositories;

namespace PowerUpBuildersWeb.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private readonly IEmployeeTaskRepository _links;

        public EmployeeTaskController(IEmployeeTaskRepository links)
        {
            _links = links;
        }

        [HttpGet("api/taskEmployees/{id}")]
        public IEnumerable<EmployeeTask> GetTaskEmployees(int id)
            => _links.GetTaskLinks(id);

        [HttpPost("/api/taskEmployees/add")]
        public void AddLink(EmployeeTask link)
        {
            _links.AssignEmployeeToTask(link);
            _links.SaveChanges();
        }

        [HttpPost("/api/taskEmployees/update")]
        public void UpdateLink(EmployeeTask link)
        {
            _links.UpdateLink(link);
            _links.SaveChanges();
        }

        [HttpPost("/api/taskEmployees/delete")]
        public void DeleteLink(EmployeeTask link)
        {
            _links.RemoveEmployeeFromTask(link.EmployeeId, link.TaskId);
            _links.SaveChanges();
        }
    }
}
