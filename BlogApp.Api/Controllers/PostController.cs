using BlogApp.Contracts.Posts.Repositories;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Contracts.Posts.Commands.GetPost;
using BlogApp.Contracts.Posts.Commands.CreatePost;

namespace BlogApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await _postService.GetPostAsync(new GetPostRequest(id), cancellationToken));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreatePostRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await _postService.CreatePostAsync(request, cancellationToken));
        }

    }
}
