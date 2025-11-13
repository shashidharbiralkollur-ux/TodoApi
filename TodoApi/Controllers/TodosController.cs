using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly TodoService _service;

        public TodosController(TodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todo = _service.Get(id);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create([FromBody] TodoItem newTodo)
        {
            var created = _service.Add(newTodo.Title ?? "Untitled");
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoItem updated)
        {
            if (!_service.Update(id, updated)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}
