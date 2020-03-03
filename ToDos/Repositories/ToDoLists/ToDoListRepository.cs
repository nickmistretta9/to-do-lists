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

            throw new NotImplementedException();
        }

        public void Delete(int toDoListID)
        {
            throw new NotImplementedException();
        }

        public ToDoList Get(object entityID)
        {
            return Models.ToDoLists.Lists.Values.FirstOrDefault(t => t.ID == (int)entityID);
        }

        public IEnumerable<ToDoList> GetCollection(object collectionID)
        {
            return Models.ToDoLists.Lists.Where(t => t.Key == (int)collectionID).Select(t => t.Value);
        }

        public void Update(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }
    }
}
