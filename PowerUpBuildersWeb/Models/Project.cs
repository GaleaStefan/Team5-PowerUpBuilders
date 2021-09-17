using System;
using System.Collections.Generic;

namespace PowerUpBuildersWeb.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }
}