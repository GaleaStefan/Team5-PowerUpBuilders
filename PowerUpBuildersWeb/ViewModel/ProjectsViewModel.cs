﻿using PowerUpBuildersWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerUpBuildersWeb.ViewModel
{
    public class ProjectsViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public Project project { get; set; }
    }
}
