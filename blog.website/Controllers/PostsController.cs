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
    [Route("[controller]")]
    //[ApiController]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        //[HttpGet("{id}")]
        public ActionResult<IEnumerable<Post>> Index()
        {
            var posts =  _postService.GetAllWithUser();
            var postResources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
            //return Ok(postResources);
            return View(postResources);
        }

        [HttpPost("")]
        public ActionResult<PostDTO> CreatePost([FromBody] SavePostDTO savePostResource)
        {
            var validator = new SavePostResourceValidator();
            var validationResult =  validator.Validate(savePostResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var postToCreate = _mapper.Map<SavePostDTO, Post>(savePostResource);
            var newPost =  _postService.CreatePost(postToCreate);
            var post =  _postService.GetPostById(newPost.Id);
            var postResource = _mapper.Map<Post, PostDTO>(post);
            return Ok(postResource);
        }

        [HttpPut("{id}")]
        public ActionResult<PostDTO> UpdatePost(int id, [FromBody] SavePostDTO savePostResource)
        {
            var validator = new SavePostResourceValidator();
            var validationResult =  validator.Validate(savePostResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
            {
                return BadRequest(validationResult.Errors);
            }

            var postToBeUpdate =  _postService.GetPostById(id);

            if(postToBeUpdate == null)
            {
                return NotFound();
            }

            var post = _mapper.Map<SavePostDTO, Post>(savePostResource);
             _postService.UpdatePost(postToBeUpdate, post);

            var updatedPost =  _postService.GetPostById(id);
            var updatedPostResource = _mapper.Map<Post, PostDTO>(updatedPost);

            return Ok(updatedPostResource);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var post =  _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
             _postService.DeletePost(post);
            return NoContent();
        }
    }
}
