using AutoMapper;
using blog.core.Models;
using blog.core.Services;
using blog.website.DTO;
using blog.website.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            var posts = await _postService.GetAllWithUser();
            var postResources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
            return Ok(postResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<PostDTO>> CreatePost([FromBody] SavePostDTO savePostResource)
        {
            var validator = new SavePostResourceValidator();
            var validationResult = await validator.ValidateAsync(savePostResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var postToCreate = _mapper.Map<SavePostDTO, Post>(savePostResource);
            var newPost = await _postService.CreatePost(postToCreate);
            var post = await _postService.GetPostById(newPost.Id);
            var postResource = _mapper.Map<Post, PostDTO>(post);
            return Ok(postResource);
        }
    }
}
