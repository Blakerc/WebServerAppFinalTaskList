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
        public ViewResult AboutUs() => View();

        [HttpGet]
        public ViewResult NewTask() => View();
        [HttpGet]
        public ViewResult Tahj() => View();
        [HttpGet]
        public ViewResult Raj() => View();
        [HttpGet]
        public ViewResult Ruairi() => View();



        //this is the method that will post the new Task
        [HttpPost]
        public IActionResult Add(TaskModel task)
        {

            tasks.Insert(task);
            tasks.Save();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            //var c = this.GetTask(id);
            return View(tasks.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(TaskModel c)
        {
            tasks.Delete(c);
            tasks.Save();
            return RedirectToAction("Index");
        }

        private TaskModel GetTask(int id)
        {
            var taskOptions = new QueryOptions<TaskModel>
            {
                Where = c => c.Id == id
            };
            var list = tasks.Get(taskOptions);
            return list;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       [HttpGet]
       public ActionResult Edit(int id)
        {
            return View("GetTask");
        }
        public ActionResult Edit(Task task)
        {
            return RedirectToAction("Index");
        }




    }

}

