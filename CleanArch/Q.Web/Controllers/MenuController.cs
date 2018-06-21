using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces;
using Q.Web.Models;

namespace Q.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Menu")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuservice;
        private readonly IOutputConverter _outputConverter;

        public MenuController(IMenuService menuservice,IOutputConverter outputConverter)
        {
            _menuservice = menuservice;
            _outputConverter = outputConverter;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var menuItems = await _menuservice.GetAll();
            if(menuItems != null)
            {
                var menuModelList = MenuModel.GetMenuItems(menuItems.ToList(), null);
                return new OkObjectResult(menuModelList);
            }
            return new OkObjectResult(_outputConverter.Map<List<MenuModel>>(menuItems));
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "GetMenu")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Menu
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Menu/5
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
