using CoreAPIExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TodoList> Get()
        {
            return _context.TodoList.ToList();
        }

        /// <summary>
        /// 藉由ID查詢
        /// </summary>
        /// <param name="id">TodoList的PK</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<TodoList> Get(Guid id)
        {
            var result = _context.TodoList.Where(x => x.TodoId == id).FirstOrDefault();

            if (result == null)
                return NotFound("找不到資源");

            return result;
        }

        /// <summary>
        /// 新增API
        /// </summary>
        /// <param name="value">TodoList的值</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TodoList> Post([FromBody] TodoList value)
        {
            _context.TodoList.Add(value);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = value.TodoId }, value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TodoList value)
        {
            if (id != value.TodoId)
                return BadRequest();

            // using Microsoft.EntityFrameworkCore; => EntityState
            _context.Entry(value).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (!_context.TodoList.Any(e => e.TodoId == id))
                    return NotFound();
                else
                    return StatusCode(500, "存取發生錯誤");
            }

            // 更新成功不回傳
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _context.TodoList.Find(id);
            if (result == null)
                return NotFound();
            _context.TodoList.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
