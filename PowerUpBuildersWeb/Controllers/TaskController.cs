using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.Repositories;

namespace PowerUpBuildersWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository repo)
        {
            _taskRepository = repo;
        }

        [HttpPost]
        public IActionResult Details(int ID)
        {
            var model = _taskRepository.GetTaskByID(ID);
            Console.Write(model.ToString());

            if(model is null)
                RedirectToAction("Index", "Home");

            return PartialView("_TaskModal", model);
        }
    }
}
