using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppFinalTaskList.Models;
using WebAppFinalTaskList.Models.DataLayer;


namespace WebAppFinalTaskList.Controllers
{
    public class HomeController : Controller
    {
        private Repository<TaskModel> tasks { get; set; }

        public HomeController(TaskContext ctx)
        {
            tasks = new Repository<TaskModel>(ctx);

        }

        public ViewResult Index(int id)
        {
            //return View();
            var taskOptions = new QueryOptions<TaskModel>
            {
            };
            return View(tasks.List(taskOptions));
        }

        [HttpGet]
        public ViewResult NewTask() => View();

        //this is the method that will post the new Task
        [HttpPost]
        public IActionResult Add(TaskModel task)
        {

                tasks.Insert(task);
                tasks.Save();
                return RedirectToAction("Index");


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
