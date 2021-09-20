using System.ComponentModel.DataAnnotations;

namespace PowerUpBuildersWeb.Models
{
    public class EmployeeTask
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }

        [Required]
        public Task Task { get; set; }
        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public int EstimatedHours { get; set; }
        public int ActualHours { get; set; }
    }
}