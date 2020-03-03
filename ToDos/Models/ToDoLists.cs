using System.Collections.Generic;

namespace ToDos.Models
{
    public static class ToDoLists
    {
        private static Dictionary<int, ToDoList> _toDoLists;

        public static Dictionary<int, ToDoList> Lists
        {
            get
            {
                if(_toDoLists == null)
                {
                    _toDoLists = new Dictionary<int, ToDoList>();
                }

                return _toDoLists;
            }
        }
    }
}
