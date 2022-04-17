using CoreAPIExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreAPIExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly Core3APIExerciseContext _context;

        public TodoController(Core3APIExerciseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TodoList> Get()
        {
            return _context.TodoList.ToList();
        }

        [HttpGet("{id}")]
        public TodoList Get(Guid id)
        {
            return _context.TodoList
                .Where(x => x.TodoId == id).FirstOrDefault();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
