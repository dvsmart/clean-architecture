using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.Menu;
using Q.Web.Models.Menu;

namespace Q.Web.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuGroupController : ControllerBase
    {
        private readonly IMenuService _menuGroupService;

        public MenuGroupController(IMenuService menuGroupService)
        {
            _menuGroupService = menuGroupService;
        }

        // GET: api/MenuGroup
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await _menuGroupService.GetMenuGroups();
            var groupList = groups.Select(item => new MenuGroupModel { Id = item.Id, Name = item.Name }).ToList();
            return Ok(groupList);
        }

    }
}
