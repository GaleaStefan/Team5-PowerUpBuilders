using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Project>().HasData(new Project() { Id = 1, Name = "TestProj" });
            modelBuilder.Entity<Project>().HasData(new Project() { Id = 2, Name = "Test2" });
        }
    }
}