using ToDos.Models;

namespace ToDos.Repositories.ToDoLists
{
    public interface IToDoListRepository : IRepository<ToDoList>
    {
        ToDoList Create(ToDoList toDoList);
        void Update(ToDoList toDoList);
        void Delete(int toDoListID);
    }
}
