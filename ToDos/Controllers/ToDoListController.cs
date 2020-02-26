using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDos.Models;
using ToDos.Repositories;
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
            try
            {
                int userID = 1;
                IEnumerable<ToDoList> toDoLists = _toDoListRepository.GetCollection(userID);

                return View("~/Views/ToDoLists/Index.cshtml", toDoLists);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}