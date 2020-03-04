using System;
using System.Collections.Generic;

namespace ToDos.Models
{
    public class ToDoList
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public List<ToDoListItem> ToDoListItems { get; set; }

        public int UserID { get; set; }
    }
}
