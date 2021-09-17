using Microsoft.EntityFrameworkCore;

namespace PowerUpBuildersWeb.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }
    }
}