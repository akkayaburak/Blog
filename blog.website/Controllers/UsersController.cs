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
    [Route("{controller}")]
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
        public ActionResult<IEnumerable<UserDTO>> Index()
        {
            var users =  _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return Ok(userResources);

        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            var userResource = _mapper.Map<User, UserDTO>(user);
            return Ok(userResource);
        }

        [HttpPost("")]
        public ActionResult<UserDTO> CreateUser([FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult =  validator.Validate(saveUserResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var userToCreate = _mapper.Map<SaveUserDTO, User>(saveUserResource);
            var newUser = _userService.CreateUser(userToCreate);
            var user = _userService.GetUserById(newUser.Id);
            var userResource = _mapper.Map<User, UserDTO>(user);
            return Ok(userResource);
        }
        [HttpPut("{id}")]
        public ActionResult<UserDTO> UpdateArtist(int id, [FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult =  validator.Validate(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToBeUpdated =  _userService.GetUserById(id);

            if (userToBeUpdated == null)
                return NotFound();

            var artist = _mapper.Map<SaveUserDTO, User>(saveUserResource);

             _userService.UpdateUser(userToBeUpdated, artist);

            var updatedUser = _userService.GetUserById(id);

            var updatedUserResource = _mapper.Map<User, UserDTO>(updatedUser);

            return Ok(updatedUserResource);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user =  _userService.GetUserById(id);

            _userService.DeleteUser(user);

            return NoContent();
        }
    }
}
