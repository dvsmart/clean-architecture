using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Domain.Menu;
using Q.Services.Interfaces.Menu;
using Q.Web.Models.Menu;

namespace Q.Web.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuItemController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var menuItems = await _menuService.GetAll();
            if (menuItems == null) return BadRequest();
            var enumerableMenuList = menuItems as MenuItem[] ?? menuItems.ToArray();
            var menuModelList = enumerableMenuList.Select(item => new NavigationMenuItem
            {
                AddedDate = item.AddedDate,
                Title = item.Title,
                Type = item.MenuGroup.Name,
                Url = item.Route,
                Icon = item.Icon,
                HasChildren = item.HasChildren,
                IsVisible = item.IsVisible,
                SortOrder = item.SortOrder,
                ParentMenuItemName= item.ParentId.HasValue ? enumerableMenuList.FirstOrDefault(x=>x.Id == item.ParentId)?.Title : string.Empty,
                Id = item.Id
            }).ToList();
            return new OkObjectResult(menuModelList.OrderBy(x => x.SortOrder));
        }
    }
}