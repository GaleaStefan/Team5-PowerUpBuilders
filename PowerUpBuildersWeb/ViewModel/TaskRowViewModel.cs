using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerUpBuildersWeb.ViewModel
{
    public class TaskRowViewModel
    {
        public string ParentProject { get; set; }
        public PowerUpBuildersWeb.Models.Task Task { get; set; }
    }
}
