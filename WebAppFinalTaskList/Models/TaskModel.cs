using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppFinalTaskList.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter a task name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a task date and time.")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }


    }
}
