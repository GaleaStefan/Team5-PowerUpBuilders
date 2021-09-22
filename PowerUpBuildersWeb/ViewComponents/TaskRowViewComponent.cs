using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerUpBuildersWeb.ViewModel;

namespace PowerUpBuildersWeb.ViewComponents
{
    public class TaskRowViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PowerUpBuildersWeb.Models.Task task, string projectName)
        {
            TaskRowViewModel model = new() { ParentProject = projectName, Task = task };
            return await Task.FromResult((IViewComponentResult)View("TaskRow", model));
        }
    }
}
