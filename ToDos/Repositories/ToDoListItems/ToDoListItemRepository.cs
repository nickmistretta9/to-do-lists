using System;
using System.Collections.Generic;
using Bogus;
using Microsoft.Extensions.Configuration;
using ToDos.Models;

namespace ToDos.Repositories.ToDoListItems
{
    public class ToDoListItemRepository : BaseRepository, IToDoListItemRepository
    {
        public ToDoListItemRepository(IConfiguration config) : base(config) { }

        public ToDoListItem Create(ToDoListItem toDoListItem)
        {
            return new Faker<ToDoListItem>().
                Rules((f, i) =>
                {
                    i.Content = toDoListItem.Content;
                    i.DateCreated = DateTime.Now;
                    i.ID = f.Random.Int(1, 13);
                    i.Complete = false;
                    i.Title = toDoListItem.Title;
                    i.ToDoListID = toDoListItem.ToDoListID;
                });
        }

        public void Delete(ToDoListItem toDoListItem) { }

        public ToDoListItem Get(object entityID)
        {
            return new Faker<ToDoListItem>()
                .Rules((f, i) =>
                {
                    i.Content = f.Random.Words(4);
                    i.Title = f.Random.Words(4);
                    i.ID = (int)entityID;
                    i.Complete = f.Random.Bool();
                    i.ToDoListID = f.Random.Int(1, 100);
                    i.DateCreated = f.Date.Recent();
                });
        }

        public IEnumerable<ToDoListItem> GetCollection(object collectionID)
        {
            throw new NotImplementedException();
        }

        public ToDoListItem Update(ToDoListItem toDoListItem)
        {
            return new ToDoListItem
            {
                ID = toDoListItem.ID,
                ToDoListID = toDoListItem.ToDoListID,
                Complete = toDoListItem.Complete,
                Title = toDoListItem.Title,
                Content = toDoListItem.Content
            };
        }
    }
}
