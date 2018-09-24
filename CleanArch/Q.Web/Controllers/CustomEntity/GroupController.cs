using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomEntityGroupController : ControllerBase
    {
        private readonly ICEGroupService _customEntityGroupService;

        public CustomEntityGroupController(ICEGroupService customEntityGroupService)
        {
            _customEntityGroupService = customEntityGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categoriesDto = await _customEntityGroupService.GetGroups();
            var categories = Mappings.Mapper.MapToCustomEntityGroups(categoriesDto);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var groupDto = await _customEntityGroupService.GetGroupById(id);
            var group = Mappings.Mapper.MapToCustomTemplates(groupDto);
            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomEntityGroupModel customEntityGroupModel)
        {
            var groupDto = Mappings.Mapper.MapToCustomEntityGroupDto(customEntityGroupModel);
            var res = await _customEntityGroupService.AddGroup(groupDto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] CustomEntityGroupModel customEntityGroupModel)
        {
            var groupDto = Mappings.Mapper.MapToCustomEntityGroupDto(customEntityGroupModel);
            var res = await _customEntityGroupService.UpdateGroup(groupDto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _customEntityGroupService.DeleteGroup(id);
            return Ok(response);
        }
    }
}
