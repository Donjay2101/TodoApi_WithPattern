using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Entities;
using TodoApi.Services.interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        private IUserInRoleService _userInRoleService;
        public RoleController(IRoleService roleService, IUserInRoleService userInRoleService)
        {
            _roleService = roleService;
            _userInRoleService = userInRoleService;
        }
        // GET: api/Role
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roleService.GetAll());
        }

        // GET: api/Role/5
        [Route("GetByID/{id:int}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _roleService.Get(id);
            return Ok(result);
        }


        [Route("IsUserInRole/{userId:int}/{roleId:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int userId, int roleId)
        {
            var result = await _userInRoleService.IsUserInRole(userId,roleId);
            return Ok(result);
        }

        [Route("IsUserInRoleByName/{userId:int}/{roleName}")]
        [HttpGet]
        public async Task<IActionResult> Get(int userId, string roleName)
        {
            var result = await _userInRoleService.IsUserInRole(userId, roleName);
            return Ok(result);
        }


        [Route("GetUserInRoles/{Id:int}")]
        [HttpGet]
        public IActionResult Get1(int userId)
        {
            var result =  _userInRoleService.GetUserInRoles(userId);
            return Ok(result);
        }


        // POST: api/Role
        [HttpPost]
        public IActionResult Post([FromBody] Role value)
        {
            var result = _roleService.Add(value);
            return Ok(result);
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role value)
        {
            if (id > 0)
            {
                var old = _roleService.Get(id);
                old.Name = value.Name;
                var result = _roleService.Update(value);
                return Ok(result);
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var old = _roleService.Get(id);
                
                var result = _roleService.Update(old);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
