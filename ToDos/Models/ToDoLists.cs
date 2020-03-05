using System.Collections.Generic;

namespace ToDos.Models
{
    public static class ToDoLists
    {
        private static Dictionary<int, List<ToDoList>> _toDoLists;

        public static Dictionary<int, List<ToDoList>> Lists
        {
            get
            {
                if(_toDoLists == null)
                {
                    _toDoLists = new Dictionary<int, List<ToDoList>>();
                }

                return _toDoLists;
            }
        }
    }
}
