using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Entities;
using TodoApi.Services.interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var result = _userService.GetAll().ToList();
            return Ok(result);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _userService.Get(id);
            return Ok(result);
        }


        [Route("GetByName/{name}")]
        [HttpGet]
        public IActionResult GetByName(string username)
        {
            var result = _userService.GetBy(x => x.Name == username).FirstOrDefault();
            return Ok(result);
        }

        [Route("GetByEmail/{email}")]
        [HttpGet("{id}", Name = "Email")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetBy(x => x.Mail == email).FirstOrDefault();
            return Ok(result);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            var services = _userService.Add(value).GetAwaiter().GetResult();
            return Ok(services);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            if (id > 0)
            {
                var old = _userService.Get(id);
                if(old != null)
                {
                    old.Name = value.Name;
                    old.Mail = value.Mail;
                }

                var services = _userService.Update(old).GetAwaiter().GetResult();
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var old = _userService.Get(id);
                var services = _userService.Delete(old).GetAwaiter().GetResult();
            }
            return Ok();
        }
    }
}
