using ToDos.Models;

namespace ToDos.Repositories.ToDoListItems
{
    public interface IToDoListItemRepository : IRepository<ToDoListItem>
    {
        ToDoListItem Create(ToDoListItem toDoListItem);

        void Delete(ToDoListItem toDoListItem);

        ToDoListItem Update(ToDoListItem toDoListItem);
    }
}
