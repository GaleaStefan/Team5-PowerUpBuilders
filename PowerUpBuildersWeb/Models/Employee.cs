using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerUpBuildersWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<EmployeeTask> Tasks { get; set; } = new();

    }
}