using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repository
{
    public class MyDbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            // makes sure the database is there. If not, it makes it. Will need to keep.
            context.Database.EnsureCreated();



            // if there are any Todos in the database do nothing. This might be removed. I just added the Todo1 and Tag for testing.
            if (context.Todos.Any())
            {
                return;
            }
            // If there are no Todos do the following:

            Todo todo1 = new Todo()

            {
                Description = "This is todo 1. It is active",
                Name = "Todo1",
                DueDate = DateTime.UtcNow,
                Active = true
            };
            Todo todo2 = new Todo()
            {
                Description = "This is todo 2. It is complete",
                Name = "Todo2",
                DueDate = DateTime.UtcNow,
                Active = false

            };
            Todo todo3 = new Todo()
            {
                Description = "This is todo 3 which is also active",
                Name = "Todo3",
                DueDate = DateTime.UtcNow,
                Active = true

            };
            Todo todo4 = new Todo()
            {
                Description = "Todo 4 is completed",
                Name = "Todo4",
                DueDate = DateTime.UtcNow,
                Active = false
            };
            // Adds todo1 to the database
            context.Todos.Add(todo1);
            context.Todos.Add(todo2);
            context.Todos.Add(todo3);
            context.Todos.Add(todo4);

            // here I initialize a tag to the project created above. Just for testing. Name is the tag (many Tags to 1 Todo).
            //                                                                         Todo is reference to specific Todo
            Tag tag1 = new Tag()
            {
                Name = "first",
                Todo = todo1
            };
            Tag tag2 = new Tag()
            {
                Name = "tag",
                Todo = todo1
            };
            Tag tag3 = new Tag()
            {
                Name = "second",
                Todo = todo2
            };
            Tag tag4= new Tag()
            {
                Name = "tag",
                Todo = todo2
            };
            Tag tag5 = new Tag()
            {
                Name = "third",
                Todo = todo3
            };
            Tag tag6 = new Tag()
            {
                Name = "fourth",
                Todo = todo4
            };
            context.Tags.Add(tag1);
            context.Tags.Add(tag2);
            context.Tags.Add(tag3);
            context.Tags.Add(tag4);
            context.Tags.Add(tag5);
            context.Tags.Add(tag6);

            Warning warning = new Warning()
            {
                Days = 2,
                Hours = 0
            };
            context.Warnings.Add(warning);

            // Commits changes to database
            context.SaveChanges();
        }
    }
}
