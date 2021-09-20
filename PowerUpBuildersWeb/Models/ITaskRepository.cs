﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerUpBuildersWeb.Models
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
    }
}
