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
    [Route("api/{controller}")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return Ok(userResources);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            var userResource = _mapper.Map<User, UserDTO>(user);
            return Ok(userResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var userToCreate = _mapper.Map<SaveUserDTO, User>(saveUserResource);
            var newUser = await _userService.CreateUser(userToCreate);
            var user = await _userService.GetUserById(newUser.Id);
            var userResource = _mapper.Map<User, UserDTO>(user);
            return Ok(userResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateArtist(int id, [FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToBeUpdated = await _userService.GetUserById(id);

            if (userToBeUpdated == null)
                return NotFound();

            var artist = _mapper.Map<SaveUserDTO, User>(saveUserResource);

            await _userService.UpdateUser(userToBeUpdated, artist);

            var updatedUser = await _userService.GetUserById(id);

            var updatedUserResource = _mapper.Map<User, UserDTO>(updatedUser);

            return Ok(updatedUserResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);

            await _userService.DeleteUser(user);

            return NoContent();
        }
    }
}
