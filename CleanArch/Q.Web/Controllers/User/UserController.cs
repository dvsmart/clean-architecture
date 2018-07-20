using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService, IOutputConverter outputConverter)
        {
            _userService = userService;
            _outputConverter = outputConverter;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get(int page, int pageSize)
        {
            var data = _userService.GetAll(page, pageSize);
            if(data != null && data.Result != null)
            {
                var users = data.Result.Results != null ? _outputConverter.Map<List<UserListModel>>(data.Result.Results) : null;
                var result = users.GetPagedResult(data.Result.PageSize, data.Result.CurrentPage, data.Result.RowCount);
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
