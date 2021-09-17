using System.Collections.Generic;

namespace PowerUpBuildersWeb.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskNumber { get; set; }
        public TaskStatus Status { get; set; }
        public List<string> Images { get; set; } = new();
        public List<string> Files { get; set; } = new();
        public List<EmployeeTask> Employees { get; set; } = new();
    }
}