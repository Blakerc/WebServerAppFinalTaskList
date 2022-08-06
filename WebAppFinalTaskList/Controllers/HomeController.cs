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

        private TaskContext context { get; set; }

        public HomeController(TaskContext ctx)
        {
            tasks = new Repository<TaskModel>(ctx);
            context = ctx;
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
            if (ModelState.IsValid)
            {
                tasks.Insert(task);
                tasks.Save();
                return RedirectToAction("Index");
            } else
            {
                return View("NewTask", task);
            }
            
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

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            var task = context.Tasks.Where(task => task.Id == Id).FirstOrDefault();
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Update(task);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(task);
            }
            
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
        public ActionResult Edit(Task task)
        {
            return RedirectToAction("Index");
        }




    }

}

