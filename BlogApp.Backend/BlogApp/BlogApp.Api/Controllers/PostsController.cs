using BlogApp.Logic;
using BlogApp.Logic.Models.Posts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ILogicLayer _logic;
        public PostsController(ILogicLayer logic)
        {
            _logic = logic;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayPostModel>>> GetPostsAsync()
        {
            return Ok(await _logic.GetPostsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayPostModel>> GetPostAsync(string id) 
        {
            if (id.Length != 24)
                return BadRequest("Not a valid ID");

            var success = await _logic.GetPostAsync(id);

            if(success.Id == null)
                return NotFound();
            else
                return Ok(success);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreatePostAsync(PostModel newPost)
        {
            var success = await _logic.CreatePostAsync(newPost);

            if (success == false)
                return StatusCode(500, success);
            else
                return Ok(success);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdatePostAsync(string id, PostModel updatePost) =>
            await _logic.UpdatePostAsync(id, updatePost);

        [HttpDelete("{id}")]
        public async Task<bool> DeletePostAsync(string id) =>
            await _logic.DeletePostAsync(id);
    }
}
