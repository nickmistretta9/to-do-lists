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
            toDoListItem.ID = Models.ToDoLists.Lists.Count + 1;
            toDoListItem.DateCreated = DateTime.Now;

            Models
                .ToDoLists
                .Lists[toDoListItem.UserID]
                .FirstOrDefault(l => l.ID == toDoListItem.ToDoListID)
                .ToDoListItems
                .ToList()
                .Add(toDoListItem);

            return toDoListItem;
        }

        public void Delete(int toDoListItemID) 
        {
            ToDoListItem itemToDelete = Get(toDoListItemID);
            Models
                .ToDoLists
                .Lists[itemToDelete.UserID]
                .FirstOrDefault(l => l.ID == itemToDelete.ToDoListID)
                .ToDoListItems
                .ToList()
                .Remove(itemToDelete);
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
