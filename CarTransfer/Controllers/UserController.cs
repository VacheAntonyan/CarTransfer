using Microsoft.AspNetCore.Mvc;

namespace CarTransfer.Controllers
{
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (_userService.Register(request.Username, request.Password))
            {
                return Ok("User registered successfully");
            }

            return BadRequest("Username already exists");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (_userService.VerifyLogin(request.Username, request.Password))
            {
                return Ok("Login successful");
            }

            return Unauthorized("Invalid username or password");
        }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

