using AutoMapper;
using EmployeeManagement.DataAccess.DTOs;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly Services.Interfaces.IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IActualSalaryService _actualSalaryService;
        public AuthenController(IMapper mapper, IUserService userService, Services.Interfaces.IAuthenticationService authenticationService, IActualSalaryService actualSalaryService)
        {
            _mapper = mapper;
            _userService = userService;
            _authenticationService = authenticationService;
            _actualSalaryService = actualSalaryService;
        }
        
        [HttpPost("SignIn")]
        public async Task<ActionResult<string>> Login(UserLoginRequestDTO login)
        {

            var user = _userService.GetUserByUserName(login.UserName);
            if (user != null)
            {
                if (login.UserName != user.UserName)
                {
                    return BadRequest("User not found.");
                }
                if (login.Password != user.Password)
                {
                    return BadRequest("Wrong password");
                }


                string token = _authenticationService.CreateToken(user);
                var refreshToken = _authenticationService.GenerateRefreshToken();
                _authenticationService.SetRefreshToken(user, refreshToken);

                return Ok(token);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(UserRegisterRequestDTO request)
        {
            var existingUser = _userService.GetUserByUserName(request.UserName);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "Username already exists." });
            }

            var newUser = _mapper.Map<UserRegisterRequestDTO, User>(request);

            newUser.Password = request.Password;
            newUser.DaysOff = 0;

            _userService.CreateUser(newUser);


            var userResponse = _mapper.Map<User, UserDTO>(newUser);

            return Ok(userResponse);

        }
    }
}
