using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            var users = _outputConverter.Map<List<UserListModel>>(data.Results);
            return new OkObjectResult(users.GetPagedResult(data.PageSize, data.CurrentPage, data.RowCount));
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
