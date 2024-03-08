using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Services;
using RapidRetail.Infrastructure.Services;

namespace RapidRetail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ILogger<AuthController> logger, IConfiguration configuration, IAuthService authService)
        : ControllerBase
    {
        // POST: api/<LoginController>
        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Login([FromBody] LoginRequestModel userLogin)
        {
            try
            {
                var user = authService.Authenticate(userLogin);
                if (user != null)
                {
                    var token = JwtService.GenerateToken(configuration, user);
                    return Ok(token);
                }

                return Unauthorized("Username or password is incorrect");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return Unauthorized("Username or password is incorrect");
            }
        }
    }
}
