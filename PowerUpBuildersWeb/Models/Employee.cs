using System.Collections.Generic;

namespace PowerUpBuildersWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeTask> Tasks { get; set; } = new();

    }
}