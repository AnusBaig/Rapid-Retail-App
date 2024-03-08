using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Services;
using RapidRetail.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidRetail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        // POST: api/<LoginController>
        [AllowAnonymous]
        [HttpPost("token")]
        public ActionResult Login([FromBody] LoginRequestModel userLogin)
        {
            var user = _authService.Authenticate(userLogin);
            if (user != null)
            {
                var token = JwtService.GenerateToken(_configuration, user);
                return Ok(token);
            }

            return NotFound("Username or password is incorrect");
        }
    }
}
