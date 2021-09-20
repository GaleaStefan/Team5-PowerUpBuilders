using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerUpBuildersWeb.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }
}