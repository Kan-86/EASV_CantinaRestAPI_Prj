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
        private IUserRepositories _userService;
        private IAuthenticationHelper _authenticationHelper;

        public AuthenticationController(IUserRepositories userService,
            IAuthenticationHelper authService)
        {
            _userService = userService;
            _authenticationHelper = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _userService.ReadAllUsers().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!_authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                user.IsAdmin,
                token = _authenticationHelper.GenerateToken(user)
            });
        }
    }
}