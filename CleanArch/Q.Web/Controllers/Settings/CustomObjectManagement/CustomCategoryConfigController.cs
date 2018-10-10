using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Dtos.CustomEntity;
using Q.Services.Interfaces.Settings.CustomEntityManagement;

namespace Q.Web.Controllers.Settings.CustomObjectManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomCategoryConfigController : ControllerBase
    {
        private readonly ICustomEntityManagementService _customEntityManagementService;

        public CustomCategoryConfigController(ICustomEntityManagementService customEntityManagementService)
        {
            _customEntityManagementService = customEntityManagementService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _customEntityManagementService.GetCustomGroups();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categories = await _customEntityManagementService.GetCustomGroups();
            var filterCategories = categories.Where(x => x.Id == id);
            return Ok(filterCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomGroupDto createCustomGroupRequest)
        {
            var response = await _customEntityManagementService.AddCustomGroup(createCustomGroupRequest);
            return Ok(response);
        }
        
    }
}
