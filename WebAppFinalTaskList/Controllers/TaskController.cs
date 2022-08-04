using Microsoft.AspNetCore.Mvc;
using WebAppFinalTaskList.Models;
using WebAppFinalTaskList.Models.DataLayer;

namespace WebAppFinalTaskList.Controllers
{
    public class TaskController : Controller
    {
        private Repository<TaskModel> tasks { get; set; }
        public TaskController(TaskContext ctx) => tasks = new Repository<TaskModel>(ctx);
/*
        [HttpPost]
        public IActionResult Add(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                tasks.Insert(task);
                tasks.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }
*/
    }
}
