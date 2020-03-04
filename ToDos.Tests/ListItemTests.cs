using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using ToDos.Models;
using ToDos.Repositories.ToDoListItems;
using ToDos.Repositories.ToDoLists;

namespace ToDos.Tests
{
    public class ListItemTests
    {
        private IToDoListItemRepository _toDoListItemRepository;
        private IToDoListRepository _toDoListRepository;

        [SetUp]
        public void Setup()
        {
            _toDoListItemRepository = new ToDoListItemRepository();
            _toDoListRepository = new ToDoListRepository();
            ToDoLists.Lists.Clear();
        }

        [Test]
        public void AddListItem()
        {
            ToDoLists.Lists.Add(1, new List<ToDoList>());
            ToDoList toDoList = new ToDoList
            {
                UserID = 1,
                Title = "Test List"
            };

            var insertedToDoList = _toDoListRepository.Create(toDoList);

            var toDoListItem = new ToDoListItem
            {
                UserID = 1,
                Title = "Test Item 1",
                ToDoListID = insertedToDoList.ID,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"                
            };

            var insertedItem = _toDoListItemRepository.Create(toDoListItem);

            Assert.AreEqual(1, insertedItem.ID);
        }
        [Test]
        public void MultipleListItems()
        {
            ToDoLists.Lists.Add(1, new List<ToDoList>());
            ToDoList toDoList = new ToDoList
            {
                UserID = 1,
                Title = "Test list"
            };

            var insertedList = _toDoListRepository.Create(toDoList);
            var firstItem = new ToDoListItem
            {
                UserID = 1,
                Title = "Test item 1",
                ToDoListID = insertedList.ID,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
            };

            _toDoListItemRepository.Create(firstItem);

            var secondItem = new ToDoListItem
            {
                UserID = 1,
                Title = "Test item 2",
                ToDoListID = insertedList.ID,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
            };

            var insertedItem = _toDoListItemRepository.Create(secondItem);

            Assert.AreEqual(2, insertedItem.ID);
            Assert.AreEqual(2, ToDoLists.Lists[1].FirstOrDefault(l => l.ID == insertedList.ID).ToDoListItems.Count());
        }

        [Test]
        public void DeleteListItem()
        {
            ToDoLists.Lists.Add(1, new List<ToDoList>());
            ToDoList toDoList = new ToDoList
            {
                UserID = 1,
                Title = "Test list"
            };

            var insertedList = _toDoListRepository.Create(toDoList);
            var listItem = new ToDoListItem
            {
                UserID = 1,
                Title = "Test item 1",
                ToDoListID = insertedList.ID,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
            };

            var insertedItem = _toDoListItemRepository.Create(listItem);
            _toDoListItemRepository.Delete(insertedItem);

            Assert.AreEqual(0, ToDoLists.Lists[1].FirstOrDefault(l => l.ID == insertedList.ID).ToDoListItems.Count());
        }
    }
}
