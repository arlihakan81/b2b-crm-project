using CRM.Application.Interfaces;
using CRM.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController(IAuthenticateService authService) : ControllerBase
    {
        readonly IAuthenticateService _authService = authService;

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> AuthenticateAsync(LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request.Email, request.Password);
            return token is null ? BadRequest() : Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            await _authService.RegisterAsync(request);
            return Ok("You have been registered...");
        }


    }
}
