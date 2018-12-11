using System.Linq;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Models;
using EASV_CantinaRestAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EASV_CantinaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserRepositories repository;
        private IAuthenticationHelper authenticationHelper;

        public AuthenticationController(IUserRepositories repos,
            IAuthenticationHelper authService)
        {
            repository = repos;
            authenticationHelper = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = repository.ReadAllUsers().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                user.IsAdmin,
                token = authenticationHelper.GenerateToken(user)
            });
        }
    }
}