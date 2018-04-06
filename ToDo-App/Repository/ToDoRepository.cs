using Microsoft.EntityFrameworkCore;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private MyDbContext context;

        public TodoRepository(MyDbContext context)
        {
            this.context = context;

        }


        public Todo Add(Todo todo)
        {
            this.context.Todos.Add(todo);
            this.context.SaveChanges();
            // return todo just in case client needs new unique identifier. this will give handle
            return todo;
        }

        public IEnumerable<Todo> GetAll()
        {
            // ToList - take that list and do a select * from Todos. You can add joins and where clauses and anything you would do in SQL
            // you can do in link. Google to find methods to do what you want.

            //  this didnt return all tods nor tags:     return this.context.Todos.ToList(); 
            // this return does. after fixing the self referencing loop by changing the Startup.cs file.
            return this.context.Todos.Include(t => t.Tags);

        }
        // returns a todo that has the id that is passed.
        public Todo GetTodo(int todoId)
        {
            return this.context.Todos.FirstOrDefault(t=>t.TodoId == todoId);
        }

        public void Remove(int todoId)
        {
            this.context.Todos.Remove(this.context.Todos.FirstOrDefault(t => t.TodoId == todoId));
            this.context.SaveChanges();

        }

        public void Update(Todo todo)
        {
            var existingTodo = this.context.Todos.First(t => t.TodoId == todo.TodoId);
            existingTodo.Description = todo.Description;
            existingTodo.Name = todo.Name;
            existingTodo.DueDate = todo.DueDate;
            existingTodo.Active = todo.Active;
            this.context.SaveChanges();
        }
        // this groupt.Count() == tags.Length makes sure that the returned todos 
        //      contain all the tags passed in. Not just contains one of the tags.
        public IEnumerable<Todo> SearchByTags(List<string> tags)
        {
            /* this was the first method shown in class but it didn't work.
            return this.context.Tags
                .Where(tag => tags.Contains(tag.Name))
                .GroupBy(tag => tag.Todo)
                .Where(group => group.Count() == tags.Length)
                .Select(group => group.Key)
                .Include(t => t.Tags);
                // now the prof posted this following method:
                return this.context.Projects
                    .Include(p => p.Tags)
                    .Where(p => tags.All(tag => p.Tags.Any(t => t.Name == tag)));


                return this.context.Projects
                    .Include(p => p.Tags)
                    .Where(p => tags.All(tag => p.Tags.Any(t => t.Name == tag)));
        
                    // which i then changed to the following below where t is todo and tg is tag: (Still didnt work so gave up)
                    // I ditched this below method for now and went back to result without the tags.

            return this.context.Todos
                    .Include(t => t.Tags)
                    .Where(t => tags.All(tag => t.Tags.Any(tg => tg.Name == tag)));
             */
        //    return this.context.Tags
        //       .Where(tag => tags.Contains(tag.Name))
        //       .GroupBy(tag => tag.Todo)
        //       .Where(group => group.Count() == tags.Length)
        //       .Select(group => group.Key);
            return this.context.Todos
                    .Include(p => p.Tags)
                    .Where(p => tags.All(tag => p.Tags.Any(t => t.Name == tag)));
        }



        /*    Not sure if in need to and all this stuff. So far the tags got added to the Tag table
         *        but idk if will need this for update and delete of the tags. Will SEE
                public Tag AddTag(Tag tag)
                {
                    this.context.Tag.Add(tag);
                    this.context.SaveChanges();
                    //return the tag just in case client needs new unique identifier. this will give handle (for debugging)
                    return tag;
                }
                public IEnumerable<Tag> GetAllTag()
                {
                    // ToList - take that list and do a select * from Tag. You can add joins and where clauses and anything you would do in SQL
                    // you can do in linq. Google to find methods to do what you want.
                    return this.context.Tag.ToList();
                }
                public void RemoveTag(int tagId)
                {
                    this.context.Tag.Remove(this.context.Tag.FirstOrDefault(t => t.TagId == tagId));
                    this.context.SaveChanges();

                }

                public void UpdateTag(Tag tag)
                {
                    var existingTag = this.context.Tag.First(t => t.TagId == tag.TagId);
                    existingTag.Name = tag.Name;
                    existingTag.Todo = tag.Todo;
                    this.context.SaveChanges();
                }
        */
    }
}
