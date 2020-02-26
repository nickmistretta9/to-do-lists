using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.Extensions.Configuration;
using ToDos.Models;

namespace ToDos.Repositories.ToDoLists
{
    public class ToDoListRepository : BaseRepository, IToDoListRepository
    {
        public ToDoListRepository(IConfiguration config) : base(config) { }

        public ToDoList Create(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }

        public void Delete(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }

        public ToDoList Get(object entityID)
        {
            Random rand = new Random();
            ToDoList toDoList = new Faker<ToDoList>()
                .Rules((f, t) =>
                {
                    t.ID = (int)entityID;
                    t.Title = f.Random.Words(4);
                    t.DateCreated = DateTime.Now;
                    t.ToDoListItems = new List<ToDoListItem>(rand.Next(3, 12));
                });

            for (int i = 0; i < toDoList.ToDoListItems.Count(); i++)
            {
                toDoList.ToDoListItems.ToList().Add(
                    new Faker<ToDoListItem>()
                    .Rules((f, l) =>
                    {
                        l.ToDoListID = toDoList.ID;
                        l.Title = f.Random.Words(4);
                        l.Content = f.Random.Words(20);
                        l.DateCreated = DateTime.Now;
                        l.Complete = f.Random.Bool();
                    })
                );
            }

            return toDoList;
        }

        public IEnumerable<ToDoList> GetCollection(object collectionID)
        {
            Random rand = new Random();
            List<ToDoList> toDoLists = new List<ToDoList>();

            for (int i = 0; i < rand.Next(3, 5); i++)
            {
                toDoLists.Add(
                    new Faker<ToDoList>()
                    .Rules((f, t) => {
                        t.ID = i + 1;
                        t.Title = f.Random.Words(4);
                        t.UserID = (int)collectionID;
                        t.DateCreated = DateTime.Now;
                    })
                );
            }

            toDoLists.ForEach(t =>
            {
                var listItems = new List<ToDoListItem>();
                for(int i = 0; i < rand.Next(3, 12); i++)
                {
                    listItems.Add(new Faker<ToDoListItem>()
                        .Rules((f, l) =>
                        {
                            l.ID = i + 1;
                            l.ToDoListID = t.ID;
                            l.Title = f.Random.Words(4);
                            l.DateCreated = DateTime.Now;
                            l.Content = f.Random.Words(20);
                            l.Complete = f.Random.Bool();
                        })
                    );

                    t.ToDoListItems = listItems.OrderBy(l => l.Complete);
                }
            });

            return toDoLists;
        }

        public ToDoList Update(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }
    }
}
