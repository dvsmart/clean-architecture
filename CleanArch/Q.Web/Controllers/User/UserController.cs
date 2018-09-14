using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.User;
using Q.Web.Helpers;
using Q.Web.Models.User;

namespace Q.Web.Controllers.User
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOutputConverter _outputConverter;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IOutputConverter outputConverter, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _outputConverter = outputConverter;
            _appSettings = appSettings.Value;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get(int page, int pageSize)
        {
            var data = _userService.GetAll(page, pageSize);
            if(data != null && data.Result != null)
            {
                var users = data.Result.Results != null ? _outputConverter.Map<List<UserListModel>>(data.Result.Results) : null;
                var result = users.GetPagedResult(data.Result.PageSize, data.Result.CurrentPage);
                return Ok(result);
            }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _userService.CheckIfUserExists(id);
            if(data != null)
            {
                var userModel = new UserListModel
                {
                    DisplayName = data.UserProfile.DisplayName,
                    FirstName = data.UserProfile.FirstName,
                    LastName = data.UserProfile.LastName,
                    EmailAddress = data.EmailAddress,
                    RoleName = data.UserRole.RoleName,
                    UserType = data.UserType.Name,
                    UserName = data.UserName,
                    Address = data.UserProfile.Address,
                    City = data.UserProfile.City
                };
                return Ok(userModel);
            }
            return new BadRequestResult();
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]CreateNewUserRequest newUserRequest)
        {
            if(newUserRequest != null)
            {
                var up = new Domain.User.UserProfile
                {
                    FirstName = newUserRequest.FirstName,
                    LastName = newUserRequest.LastName,
                    Address = newUserRequest.Address,
                    DateOfBirth = DateTime.Now,
                };
                var user = new Domain.User.User
                {
                    EmailAddress = newUserRequest.EmailAddress,
                    UserRoleId = newUserRequest.RoleId,
                    UserTypeId = newUserRequest.TypeId,
                    UserProfile = up
                };
                _userService.Add(user);
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginModel userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                user.Id,
                Username = user.UserName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel userDto)
        {
            // map dto to entity
            var user = new Domain.User.User
            {
                UserName = userDto.Username,
                EmailAddress = userDto.Email,
                UserRoleId = 1,
                UserTypeId = 1
            };

            try
            {
                // save 
                var userInfo = _userService.Create(user, userDto.Password);
                return Ok(userInfo);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
