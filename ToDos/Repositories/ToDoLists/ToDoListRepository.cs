using System;
using System.Collections.Generic;
using System.Linq;
using ToDos.Models;

namespace ToDos.Repositories.ToDoLists
{
    public class ToDoListRepository : BaseRepository, IToDoListRepository
    {        
        public ToDoList Create(ToDoList toDoList)
        {
            toDoList.ID = Models.ToDoLists.Lists.Count + 1;
            toDoList.DateCreated = DateTime.Now;

            Models.ToDoLists.Lists[toDoList.UserID].Add(toDoList);

            return toDoList;
        }

        public void Delete(int toDoListID)
        {
            int key = Models.ToDoLists.Lists.Values.Select(t => t.FirstOrDefault(l => l.ID == toDoListID).ID).FirstOrDefault();
        }

        public ToDoList Get(object entityID)
        {
            return Models
                .ToDoLists
                .Lists
                .Values
                .Select(t => t.FirstOrDefault(l => l.ID == (int)entityID))?
                .FirstOrDefault();
        }

        public IEnumerable<ToDoList> GetCollection(object collectionID)
        {
            return Models
                .ToDoLists
                .Lists
                .Where(t => t.Key == (int)collectionID)?
                .SelectMany(t => t.Value);
        }

        public void Update(ToDoList toDoList)
        {
            var existingList = Models.ToDoLists.Lists[toDoList.UserID].FirstOrDefault(t => t.ID == toDoList.ID);
            if(existingList != null)
            {
                existingList.Title = toDoList.Title;
                existingList.ToDoListItems = toDoList.ToDoListItems;
            }
        }
    }
}
