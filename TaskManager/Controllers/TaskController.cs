using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IRepositoryTasks _repositoryTask;

        public TaskController(ILogger<TaskController> logger, IRepositoryTasks repositoryTodo)
        {
            _logger = logger;
            _repositoryTask = repositoryTodo;
        }

        public IActionResult Index()
        {
            var todos = _repositoryTask.GetAllTodos();

            var taskViewModel = new TodoViewModel
            {
                Todos = todos.OrderByDescending(todoA => todoA.EndDate).Reverse()
            };

            return View(taskViewModel);
        }

        public IActionResult Create()
        {
            return View("CreateForm");
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _repositoryTask.AddTodo(todo);
            return RedirectToAction("Index");
        }


        public IActionResult Update(Guid Id)
        {
            var todo = _repositoryTask.GetById(Id);

            return View("UpdateForm", todo);
        }

        [HttpPost]
        public IActionResult Update(Todo todo)
        {
            _repositoryTask.UpdateTodo(todo);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            _repositoryTask.DeleteTodo(Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}