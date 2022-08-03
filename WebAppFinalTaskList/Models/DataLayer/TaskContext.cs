using Microsoft.EntityFrameworkCore;

namespace WebAppFinalTaskList.Models.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
        { }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().HasData(
            new TaskModel
            {
                Id = 1,
                Title = "Demo Task",
                Description = "This is a test task",
                TaskDateTime = new System.DateTime(2015, 12, 25)
        }
            );
        }
    }
}
