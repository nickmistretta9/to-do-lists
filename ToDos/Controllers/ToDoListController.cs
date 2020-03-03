using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDos.Models;
using ToDos.Repositories.ToDoLists;

namespace ToDos.Controllers
{
    public class ToDoListController : Controller
    {
        //private readonly IToDoListRepository _toDoListRepository;

        //public ToDoListController(IToDoListRepository toDoListRepository)
        //{
        //    _toDoListRepository = toDoListRepository;
        //}

        public IActionResult Index()
        {
            List<ToDoList> toDoLists = ToDoLists.Lists.Values.Select(t => t).ToList();

            return View("~/Views/ToDoLists/Index.cshtml", toDoLists);
        }
    }
}