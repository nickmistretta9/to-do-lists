using System.Collections.Generic;
using ToDos.Models;

namespace ToDos.Repositories.ToDoListItems
{
    public interface IToDoListItemRepository : IRepository<ToDoListItem>
    {
        ToDoListItem Create(ToDoListItem toDoListItem);

        void Delete(int toDoListItemID);

        void Update(ToDoListItem toDoListItem);

        ToDoListItem Get(ToDoListItem toDoListItem);

        IEnumerable<ToDoListItem> GetCollection(ToDoList toDoList);
    }
}
