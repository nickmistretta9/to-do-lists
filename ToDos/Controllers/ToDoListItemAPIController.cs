using System;
using Microsoft.AspNetCore.Mvc;
using ToDos.Models;
using ToDos.Repositories.ToDoListItems;

namespace ToDos.Controllers
{
    [ApiController]
    public class ToDoListItemAPIController : Controller
    {
        private readonly IToDoListItemRepository _toDoListItemRepository;

        public ToDoListItemAPIController(IToDoListItemRepository toDoListItemRepository)
        {
            _toDoListItemRepository = toDoListItemRepository;
        }

        [HttpGet]
        [Route("api/items/{listItemID}")]
        public IActionResult GetToDo(int listItemID)
        {
            try
            {
                return Json(_toDoListItemRepository.Get(listItemID));
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/items/create")]
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