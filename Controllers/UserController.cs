﻿using AutoMapper;
using EmployeeManagement.DataAccess.DTOs;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        [HttpGet("all")]
        //[Authorize(Roles = "1")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetActiveUsers();
            if (!users.Any())
            {
                return NotFound("No users found");
            }
            var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserRespondDTO>>(users);

            return Ok(userDtos);
        }

        [HttpGet("{id}")] //, Authorize
        public IActionResult GetUser(int id)
        {
            /*
            var currentUserId = int.Parse(User.FindFirstValue("UserId"));
            if (currentUserId != id)
            {
                return Unauthorized("Access denied: You can only view your own information.");
            }
            */
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var userDto = _mapper.Map<User, UserRespondDTO>(user);

            return Ok(userDto);
        }

        [HttpPut("{id}")] //, Authorize(Roles = AppConstants.ADMIN_ROLE)
        public async Task<IActionResult> UpdateUser(int id, UserUpdateRequestDTO request)
        {
            var existingUser = _userService.GetUser(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            _mapper.Map(request, existingUser);

            _userService.UpdateUser(existingUser);

            return NoContent();
        }
    }
}
