using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManagerMvc.Models;
using TaskManagerRepository.Interfaces;
using TaskManagerRepository.Tables;


namespace TaskManagerMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ITaskRepository _taskRepository;

        public HomeController(ILogger<HomeController> logger, ITaskRepository taskRepository)
        {
            _logger = logger;

            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            IndexModel indexModel = new IndexModel();

            indexModel.Init(_taskRepository);

            return View(indexModel);
        }

        public IActionResult Add()
        {
            try
            {
                Task task = new Task();

                return View(task);
            }
            catch(Exception ex)
            {

            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add(Task task)
        {
            try
            {
                _taskRepository.Add(task);

                return Redirect("~/Home/Index");
            }
            catch (Exception ex)
            {

            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            try
            {
                Task task = _taskRepository.GetOneById(id);

                return View(task);
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            try
            {
                _taskRepository.Update(task);

                return Redirect("~/Home/Index");
            }
            catch (Exception ex)
            {

            }

            return View(task);
        }

        public IActionResult Remove(int id)
        {
            try
            {
                _taskRepository.RemoveById(id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

            }

            return NoContent();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
