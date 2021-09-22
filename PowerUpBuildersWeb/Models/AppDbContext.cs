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

            modelBuilder.Entity<Project>().HasData(
                new Project() { Id = 1, Name = "TestProj" },
                new Project() { Id = 2, Name = "Test2" },
                new Project() { Id = 3, Name = "Project num 3"},
                new Project() { Id = 4, Name = "Proj4"}
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "Pop Constantin" },
                new Employee() { Id = 2, Name = "Popescu Ion"},
                new Employee() { Id = 3, Name = "Aurel Vlad"},
                new Employee() { Id = 4, Name = "Popescu Ana"}
                );

            modelBuilder.Entity<Task>().HasData(
                new Task() { Id = 1, ProjectId = 1, Status = TaskStatus.New, TaskNumber = "TK20190101_01", Title = "TaskTitle", Description = "TaskDescription" },
                new Task() { Id = 2, TaskNumber = "TK202109091100_01", ProjectId = 1, Title = "Task2", Description = "Do this", Status = TaskStatus.Approved},
                new Task() { Id = 3, TaskNumber = "TK202109091100_02", ProjectId = 1, Title = "Task3", Description = "Do that", Status = TaskStatus.InProgress}
                ) ;
        }
    }
}