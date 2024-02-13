using Applications.Abstractions;
using Applications.Models.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers {

    [ApiController]
    [Route("api/v1/[controller]/auth")]
    public class UserController : ControllerBase {

        IUserService _userService;

        public UserController(IUserService userService) {
            this._userService = userService;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin(UserDto user) {
            if(_userService.SignIn(user))
                return Ok();
            else return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LogIn(string email, string password) {
            var response = _userService.LogIn(email, password);
            if (response != string.Empty)
                return Ok(response);
            return BadRequest();
        }
    }
}
