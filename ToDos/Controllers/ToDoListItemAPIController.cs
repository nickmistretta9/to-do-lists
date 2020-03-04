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
        [Route("api/items")]
        public IActionResult GetToDo([FromBody] ToDoListItem toDoListItem)
        {
            try
            {
                return Json(_toDoListItemRepository.Get(toDoListItem));
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
        [Route("api/items/delete/{toDoListItemID}")]
        public IActionResult DeleteToDo(int toDoListItemID)
        {
            try
            {
                _toDoListItemRepository.Delete(toDoListItemID);
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
                _toDoListItemRepository.Update(listItem);
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/list/items")]
        public IActionResult GetListItems(ToDoList toDoList)
        {
            try
            {
                return Json(_toDoListItemRepository.GetCollection(toDoList));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}