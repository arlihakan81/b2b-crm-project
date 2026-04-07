using CRM.Application.Interfaces;
using CRM.Application.Requests.Authenticate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController(IAuthenticateService authService) : ControllerBase
    {
        readonly IAuthenticateService authService = authService;

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await authService.AuthenticateAsync(request.Email, request.Password);
                if (token is null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await authService.RegisterAsync(request);
                return Ok("Kayıt Başarılı");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }










    }
}
