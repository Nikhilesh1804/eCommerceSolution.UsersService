using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null) 
            {
                return BadRequest();
            }

            AuthenticationResponse? response = await _usersService.Registration(registerRequest);
            if (response == null || response.Success == false) 
            {
                return BadRequest();
            }
            return Ok(response) ;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest) 
        {
            if (loginRequest == null) 
            {
                return BadRequest();
            }

            AuthenticationResponse? response = await _usersService.Login(loginRequest);
            if(response == null || response.Success == false)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}
