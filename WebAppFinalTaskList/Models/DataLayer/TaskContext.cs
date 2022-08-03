using Microsoft.EntityFrameworkCore;

namespace WebAppFinalTaskList.Models.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
        { }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
