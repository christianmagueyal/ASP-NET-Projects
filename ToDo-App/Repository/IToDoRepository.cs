using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repository
{
    public interface ITodoRepository
    {
        //Adds a Todo item to the list of Todos
        Todo Add(Todo todo);
        //Gets all the Todo items from the Todos table and returns it as an IEnumerable list of Todo objects.
        IEnumerable<Todo> GetAll();
        //Gets a Todo object from the list of Todos that has the todoId that is passed.
        Todo GetTodo(int todoId);
        //Removes the Todo object from the list of Todos that has todoId that is passed.
        void Remove(int todoId);
        //Updates the values of the Todo object that is passed into this function.
        void Update(Todo todo);
        // Returns a list of projects with the specified tags.
        IEnumerable<Todo> SearchByTags(List <string> tags);

        /*0   again. not sure if i will need this . The tags are added but idk about the delete and update of the tags.
        IEnumerable<Tag> GetAllTag();
        Tag AddTag(Tag tag);
        void RemoveTag(int tagId);
        void UpdateTag(Tag tag);
        */

    }
}
