using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppFinalTaskList.Models.Configuration
{
    internal class TaskConfig : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> entity)
        {
            entity.HasData(
               new TaskModel { Id = 2, Title = "Groceries", Description = "Pickup at kroger" },
               new TaskModel { Id = 3, Title = "Basketball Practice", Description = "At the rec center" },
               new TaskModel { Id = 4, Title = "Taco night", Description = "Soft shell pack above the fridge" },
               new TaskModel { Id = 5, Title = "Finish project", Description = "Write post routes" },
               new TaskModel { Id = 6, Title = "Send Emails", Description = "Email boss" }
            );
        }
    }
}
