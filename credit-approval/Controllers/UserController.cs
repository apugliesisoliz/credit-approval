using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using credit_approval.Contracts;
using AutoMapper;
using credit_approval.DataTransferObjects;
using credit_approval.Models;

namespace credit_approval.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public UserController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repository.User.GetAllUsers();
                var usersResult = _mapper.Map<IEnumerable<UserDto>>(users);
                return Ok(usersResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get/{userId}", Name = "UserById")]
        public IActionResult GetUserById(string userId)
        {
            try
            {
                var user = _repository.User.GetUserById(userId);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var usersResult = _mapper.Map<UserDto>(user);
                    return Ok(usersResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var userEntity = _mapper.Map<User>(user);
                userEntity.DateUpdatePassword = DateTime.Now;
                userEntity.DateValidityPassword = DateTime.Now.AddMonths(3);
                userEntity.State = true;
                _repository.User.CreateUser(userEntity);
                _repository.Save();
                var createdUser = _mapper.Map<UserDto>(userEntity);
                return CreatedAtRoute("UserById", new { userId = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{userId}")]
        public IActionResult UpdateUser(string userId, [FromBody] UserForUpdate user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var userEntity = _repository.User.GetUserById(userId);
                if (userEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(user, userEntity);
                _repository.User.UpdateUser(userEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("delete/{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            try
            {
                var userEntity = _repository.User.GetUserById(userId);
                if (userEntity == null)
                {
                    return NotFound();
                }
                userEntity.State = false;
                _repository.User.UpdateUser(userEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
