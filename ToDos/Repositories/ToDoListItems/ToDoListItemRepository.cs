using System;
using System.Collections.Generic;
using System.Linq;
using ToDos.Models;

namespace ToDos.Repositories.ToDoListItems
{
    public class ToDoListItemRepository : BaseRepository, IToDoListItemRepository
    {
        public ToDoListItem Create(ToDoListItem toDoListItem)
        {
            var list = Models.ToDoLists.Lists[toDoListItem.UserID].First(l => l.ID == toDoListItem.ToDoListID);
            toDoListItem.ID = list.ToDoListItems.Count() + 1;
            toDoListItem.DateCreated = DateTime.Now;

            list.ToDoListItems.Add(toDoListItem);

            return toDoListItem;
        }

        public void Delete(ToDoListItem toDoListItem) 
        {
            Models
                .ToDoLists
                .Lists[toDoListItem.UserID]
                .FirstOrDefault(l => l.ID == toDoListItem.ToDoListID)
                .ToDoListItems
                .Remove(toDoListItem);
        }

        public ToDoListItem Get(object entityID)
        {
            throw new NotImplementedException();
        }

        public ToDoListItem Get(ToDoListItem toDoListItem)
        {
            return Models
                .ToDoLists
                .Lists[toDoListItem.UserID]?
                .FirstOrDefault(l => l.ID == toDoListItem.ToDoListID)?
                .ToDoListItems
                .FirstOrDefault(l => l.ID == toDoListItem.ID);
        }

        public IEnumerable<ToDoListItem> GetCollection(ToDoList toDoList)
        {
            return Models
                .ToDoLists
                .Lists[toDoList.UserID]
                .FirstOrDefault(l => l.ID == toDoList.ID)
                .ToDoListItems;
        }

        public IEnumerable<ToDoListItem> GetCollection(object collectionID)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDoListItem toDoListItem)
        {
            var existingItem = Models
                .ToDoLists
                .Lists[toDoListItem.UserID]?
                .FirstOrDefault(l => l.ID == toDoListItem.ToDoListID)?
                .ToDoListItems
                .FirstOrDefault(i => i.ID == toDoListItem.ID);

            if(existingItem != null)
            {
                existingItem.Title = toDoListItem.Title;
                existingItem.Content = toDoListItem.Content;
                existingItem.Complete = toDoListItem.Complete;
            }
        }
    }
}
