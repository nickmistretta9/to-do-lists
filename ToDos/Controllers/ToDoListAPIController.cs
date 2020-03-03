﻿using System;
using System.Linq;
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
        [Route("api/lists/user/{userID}")]
        public IActionResult GetToDoLists(int userID)
        {
            try
            {
                return Json(_toDoListRepository.GetCollection(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/lists/{toDoListID}")]
        public IActionResult GetToDoList(int toDoListID)
        {
            try
            {
                return Json(_toDoListRepository.Get(toDoListID));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/lists/create")]
        public IActionResult AddToDoList([FromBody] ToDoList toDoList)
        {
            toDoList.ID = ToDoLists.Lists.Count + 1;
            toDoList.DateCreated = DateTime.Now;
            ToDoLists.Lists.Add(toDoList.UserID, toDoList);

            return Json(toDoList);
        }

        [HttpPost]
        [Route("api/lists/delete/{toDoListID}")]
        public IActionResult DeleteToDoList(int toDoListID)
        {
            try
            {
                int key = ToDoLists
                    .Lists
                    .FirstOrDefault(t => t.Value.ID == toDoListID)
                    .Value
                    .ID;

                ToDoLists.Lists.Remove(key);

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
                ToDoLists.Lists.FirstOrDefault(t => t.Value.ID == toDoList.ID).Value.Title = toDoList.Title;
                ToDoLists.Lists.FirstOrDefault(t => t.Value.ID == toDoList.ID).Value.ToDoListItems = toDoList.ToDoListItems;                
                return Json(ToDoLists.Lists.FirstOrDefault(t => t.Value.ID == toDoList.ID));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}