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

        [HttpGet]
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

        [HttpGet("{id}", Name = "OwnerById")]
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
                    var usersResult = _mapper.Map<IEnumerable<UserDto>>(user);
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var userEntity = _mapper.Map<User>(user);
                userEntity.DateUpdatePassword = DateTime.Now;
                userEntity.DateValidityPassword = DateTime.Now.AddMonths(3);
                _repository.User.CreateUser(userEntity);
                _repository.Save();
                var createdUser = _mapper.Map<UserDto>(userEntity);
                return CreatedAtRoute("OwnerById", new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
