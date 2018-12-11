using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EASV_CantinaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepositories<Users> _userRepository;

        public AuthenticationController(IUserRepositories<Users> repos)
        {
            _userRepository = repos;
        }

        // GET: api/Todo
        [Authorize]
        [HttpGet]
        public IEnumerable<Users> GetAll()
        {
            return _userRepository.ReadAllUsers();
        }

        // GET: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var item = _userRepository.GetUserByID(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Todo
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userRepository.CreateUsers(user);

            return CreatedAtRoute("Get", new { id = user.Id }, user);
        }

        // PUT: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var todo = _userRepository.GetUserByID(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Username = user.Username;
            todo.IsAdmin = user.IsAdmin;

            _userRepository.UpdateUser(todo);
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _userRepository.GetUserByID(id);
            if (todo == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUsers(id);
            return new NoContentResult();
        }
    }
}