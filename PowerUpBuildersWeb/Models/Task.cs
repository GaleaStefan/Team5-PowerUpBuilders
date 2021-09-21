using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerUpBuildersWeb.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public string TaskNumber { get; set; }
        public TaskStatus Status { get; set; }
        public List<TaskLocalFile> Files { get; set; } = new();
        public List<EmployeeTask> Employees { get; set; } = new();
    }
}