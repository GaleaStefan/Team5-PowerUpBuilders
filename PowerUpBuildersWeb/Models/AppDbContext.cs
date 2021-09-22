using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PowerUpBuildersWeb.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }
        public DbSet<TaskLocalFile> TaskLocalFiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>()
                .HasKey(et => new { et.EmployeeId, et.TaskId });

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.Tasks)
                .HasForeignKey(et => et.EmployeeId);

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Task)
                .WithMany(t => t.Employees)
                .HasForeignKey(et => et.TaskId);

            Project project = new() { Id = 1, Name = "TestProj", Tasks = new() };

            modelBuilder.Entity<Project>().HasData(project);
            modelBuilder.Entity<Project>().HasData(new Project() { Id = 2, Name = "Test2" });

            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 1, Name = "Stefan" });

            modelBuilder.Entity<Task>().HasData(new Task() { Id = 1, ProjectId = 1, Status = TaskStatus.New, TaskNumber = "TK20190101_01", Title = "TaskTitle", Description = "TaskDescription" }) ;
        }
    }
}