using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDos.Models;
using ToDos.Repositories;
using ToDos.Repositories.ToDoListItems;
using ToDos.Repositories.ToDoLists;

namespace ToDos.Controllers
{
    [ApiController]
    public class ToDoAPIController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IToDoListItemRepository _toDoListItemRepository;

        public ToDoAPIController(IToDoListRepository toDoListRepository, IToDoListItemRepository toDoListItemRepository)
        {
            _toDoListRepository = toDoListRepository;
            _toDoListItemRepository = toDoListItemRepository;
        }

        [HttpGet]
        [Route("api/items/{toDoID}")]
        public IActionResult GetToDo(int toDoID)
        {
            try
            {
                return Json(_toDoListItemRepository.Get(toDoID));
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/items/new")]
        public IActionResult AddToDo([FromBody] ToDoListItem listItem)
        {
            try
            {
                ToDoListItem insertedItem = _toDoListItemRepository.Create(listItem);

                return Json(insertedItem);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/items/delete")]
        public IActionResult DeleteToDo([FromBody] ToDoListItem listItem)
        {
            try
            {
                _toDoListItemRepository.Delete(listItem);
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/items/update")]
        public IActionResult UpdateToDo([FromBody] ToDoListItem listItem)
        {
            try
            {
                ToDoListItem toDoItem = _toDoListItemRepository.Update(listItem);
                return Json(toDoItem);
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}