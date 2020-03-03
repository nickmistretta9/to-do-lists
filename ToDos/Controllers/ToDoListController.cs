using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDos.Models;
using ToDos.Repositories.ToDoLists;

namespace ToDos.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public IActionResult Index()
        {
            int userID = 1;
            List<ToDoList> toDoLists = _toDoListRepository.GetCollection(userID).ToList();

            return View("~/Views/ToDoLists/Index.cshtml", toDoLists);
        }
    }
}