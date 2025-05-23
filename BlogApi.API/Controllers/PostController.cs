using BlogApi.Application.Dtos.PostDTO;
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
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var posts = await _postService.GetAllAsync(pageNumber, pageSize);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("getPostById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            try
            {
                var post = await _postService.GetByIdAsync(id);
                if (post == null)
                    return NotFound();

                return Ok(post);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("createPost")]
        public async Task<IActionResult> Create([FromBody] PostCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var response = await _postService.CreateAsync(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updatePost/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PostUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var response = await _postService.UpdateAsync(id, dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deletePost/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var response = await _postService.DeleteAsync(id);
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
