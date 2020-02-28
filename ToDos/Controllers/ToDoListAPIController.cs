using System;
using Microsoft.AspNetCore.Mvc;
using ToDos.Models;
using ToDos.Repositories.ToDoLists;

namespace ToDos.Controllers
{
    [ApiController]
    public class ToDoListAPIController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListAPIController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        [Route("api/lists/{toDoListID}")]
        public IActionResult GetToDoList(int toDoListID)
        {
            try
            {
                return Json(_toDoListRepository.Get(toDoListID));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/lists/create")]
        public IActionResult AddToDoList([FromBody] ToDoList toDoList)
        {
            try
            {
                ToDoList insertedList = _toDoListRepository.Create(toDoList);

                return Json(insertedList);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/lists/delete")]
        public IActionResult DeleteToDoList([FromBody] ToDoList toDoList)
        {
            try
            {
                _toDoListRepository.Delete(toDoList);
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/lists/update")]
        public IActionResult UpdateToDoList([FromBody] ToDoList toDoList)
        {
            try
            {
                ToDoList updatedList = _toDoListRepository.Update(toDoList);
                return Json(updatedList);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}