using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Entities;
using TodoApi.Services.interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }
        // GET: api/Todo
        [HttpGet]
        public IActionResult Get()
        {
            var services = _service.GetAll().ToList();
            return Ok(services);
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var services = _service.Get(id);
            return Ok(services);
        }

        // POST: api/Todo
        [HttpPost]
        public IActionResult Post(Todo todo)
        {
            var services = _service.Add(todo).GetAwaiter().GetResult();
            return Ok(services);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            if (id >0)
            {
                var todo = _service.Get(id);
                if (todo != null)
                {
                    todo.Status = !todo.Status;
                }
                var services = _service.Update(todo).GetAwaiter().GetResult();
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >0)
            {
                var todo = _service.Get(id);
                var services = _service.Delete(todo).GetAwaiter().GetResult();
            }
            return Ok();
        }
    }
}
