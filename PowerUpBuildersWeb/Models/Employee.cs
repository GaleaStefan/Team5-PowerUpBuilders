using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PowerUpBuildersWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<EmployeeTask> Tasks { get; set; } = new();

    }
}