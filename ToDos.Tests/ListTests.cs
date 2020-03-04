using ToDos.Models;
using NUnit.Framework;
using ToDos.Repositories.ToDoLists;
using System.Collections.Generic;

namespace ToDos.Tests
{
    public class Tests
    {
        private IToDoListRepository _toDoListRepository;
        [SetUp]
        public void Setup()
        {
            _toDoListRepository = new ToDoListRepository();
            ToDoLists.Lists.Clear();
        }

        [Test]
        public void AddListTest()
        {
            ToDoLists.Lists.Add(1, new List<ToDoList>());
            ToDoList toDoList = new ToDoList
            {
                UserID = 1,
                Title = "Test List"
            };

            var insertedToDo = _toDoListRepository.Create(toDoList);
            Assert.AreEqual(1, insertedToDo.ID);
        }

        [Test]
        public void MultipleListsTest()
        {
            ToDoLists.Lists.Add(1, new List<ToDoList>());
            ToDoList firstList = new ToDoList
            {
                UserID = 1,
                Title = "First List"
            };

            ToDoList secondList = new ToDoList
            {
                UserID = 1,
                Title = "Second List"
            };

            _toDoListRepository.Create(firstList);
            var secondInsert = _toDoListRepository.Create(secondList);

            Assert.AreEqual(2, secondInsert.ID);
        }

        [Test]
        public void GetListTest()
        {
            ToDoLists.Lists.Add(1, new List<ToDoList>());
            ToDoList list = new ToDoList
            {
                UserID = 1,
                Title = "This is a test list"
            };

            var insert = _toDoListRepository.Create(list);
            var insertedList = _toDoListRepository.Get(insert.ID);

            Assert.AreEqual("This is a test list", insertedList.Title);
        }

        [Test]
        public void DeleteTest()
        {
            ToDoLists.Lists.Add(1, new List<ToDoList>());
            ToDoList list = new ToDoList
            {
                UserID = 1,
                Title = "Test List"
            };

            var insert = _toDoListRepository.Create(list);
            _toDoListRepository.Delete(insert.ID);

            Assert.AreEqual(0, ToDoLists.Lists[1].Count);
        }
    }
}