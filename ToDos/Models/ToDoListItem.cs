using System;

namespace ToDos.Models
{
    public class ToDoListItem
    {
        public int ID { get; set; }

        public int ToDoListID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool Complete { get; set; }

        public DateTime DateCreated { get; set; }

        public int UserID { get; set; }
    }
}
