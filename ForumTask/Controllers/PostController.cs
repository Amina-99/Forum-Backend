using ForumTask.Models.DTOs;
using ForumTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPostsFromDb(int id)
        {
            var posts = await _postService.GetUserFromDb(id);
            return Ok(posts);
        }
    }
}
