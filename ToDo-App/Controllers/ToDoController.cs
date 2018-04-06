using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Repository;
using Project1.Models;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private ITodoRepository todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }



        // GET: api/todo/
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(todoRepository.GetAll());
        }

        // GET api/todo/"id"     this returns single todo item from the todos list.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(todoRepository.GetTodo(id));
        }
        // GET search list by tags     this returns todo item based on tags passed in. uses query parameter.
        // Example: api/todo/search
        [HttpGet("search")]
        // '[FromUri] string tagFilter' will look at request comming in and if there is a query parameter on
        //that request thats named tagFilter, it will take whats in that parameter and auto populate it for us.
        public IActionResult SearchByTags([FromUri] string tagFilter)   

        {
            // hint: have users add into a javascript array. then take that array and make combine into a
            //       single query string and then that string will be separated by commas.
            //      So .... dont let users enter in strings with commas.
            var tags = tagFilter.Split(',');
            return new ObjectResult(todoRepository.SearchByTags(tags.ToList()));
        }
        // POST api/todo
        [HttpPost]
        public IActionResult Post([FromBody]Todo todo)
        {
            var newTodo = todoRepository.Add(todo);
            return Created("api/todo", todo);
        }

        // PUT api/todo/"id"
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Todo value)
        {
            todoRepository.Update(value);
            return Ok();
        }

        // DELETE api/todo/"id"
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            todoRepository.Remove(id);
            return Ok();
        }
    }
}
