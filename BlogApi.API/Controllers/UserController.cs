using BlogApi.Application.Dtos.UserDTO;
using BlogApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BlogApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var users = await _userService.GetAllAsync(pageNumber, pageSize);
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest();
            }
         
        }

        [HttpGet("getUserById")]
        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {

                Log.Error(ex, ex.Message);
                return BadRequest();
            }
 
        }

        [AllowAnonymous]
        [HttpPost("createUser")]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var response = await _userService.CreateAsync(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {

                Log.Error(ex, ex.Message);
                return BadRequest();
            }

        }

        [HttpPut("updateUser/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var response = await _userService.UpdateAsync(id, dto);
                return Ok(response);
            }
            catch (Exception ex)
            {

                Log.Error(ex, ex.Message);
                return BadRequest();
            }
       
        }

        [HttpDelete("deleteUser{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            try
            {
                var response = await _userService.DeleteAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {

                Log.Error(ex, ex.Message);
                return BadRequest();
            }

        }
    }

}
