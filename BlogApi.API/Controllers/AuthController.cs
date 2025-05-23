using BlogApi.Application.Dtos.AuthDto;
using BlogApi.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BlogApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController( IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            try
            {
                var token = await _jwtTokenGenerator.GenerateToken(loginDto.Username, loginDto.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Login failed");
                return StatusCode(500, "An error occurred during login.");
            }
        }
    }
}
