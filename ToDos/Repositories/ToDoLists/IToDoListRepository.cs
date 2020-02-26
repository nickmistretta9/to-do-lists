using ToDos.Models;

namespace ToDos.Repositories.ToDoLists
{
    public interface IToDoListRepository : IRepository<ToDoList>
    {
        ToDoList Create(ToDoList toDoList);
        ToDoList Update(ToDoList toDoList);
        void Delete(ToDoList toDoList);
    }
}
