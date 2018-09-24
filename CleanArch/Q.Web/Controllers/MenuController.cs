using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces;
using Q.Web.Models;

namespace Q.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Menu")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var menuItems = await _menuService.GetAll();
            if (menuItems == null) return BadRequest();
            var menuModelList = MenuModel.GetMenuItems(menuItems.OrderBy(x=>x.SortOrder).ToList(), null);
            return new OkObjectResult(menuModelList);
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
