using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces;
using Q.Web.Mappings;
using Q.Web.Models;
using Q.Web.Models.Menu;

namespace Q.Web.Controllers.Menu
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
            var menuModelList = Mapper.GetMenuItems(menuItems.OrderBy(x=>x.SortOrder).ToList(), null);
            return new OkObjectResult(menuModelList);
        }
    
    }
}
