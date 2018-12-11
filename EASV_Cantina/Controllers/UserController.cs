using System;
using System.Collections.Generic;
using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.ApplicationServices.Services;
using CantinaApp.Core.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV_CantinaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersServices _userServices;

        public UserController(IUsersServices userServices)
        {
            _userServices = userServices;
        }

        // GET: api/Authentication
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetAll()
        {
            try
            {
                return Ok(_userServices.GetUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Authentication/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var item = _userServices.FindUsersId(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Authentication
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userServices.AddUsers(user);

            return CreatedAtRoute("Get", new { id = user.Id }, user);
        }

        // PUT: api/Authentication/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var todo = _userServices.FindUsersId(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Username = user.Username;
            todo.IsAdmin = user.IsAdmin;

            _userServices.UpdateUsers(todo);
            return new NoContentResult();
        }

        // DELETE: api/Authentication/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _userServices.FindUsersId(id);
            if (todo == null)
            {
                return NotFound();
            }

            _userServices.DeleteUser(id);
            return new NoContentResult();
        }
    }
}