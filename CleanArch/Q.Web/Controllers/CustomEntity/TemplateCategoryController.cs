using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateCategoryController : ControllerBase
    {
        private readonly ITemplateCategoryService _customEntityCategoryService;

        public TemplateCategoryController(ITemplateCategoryService customEntityCategoryService)
        {
            _customEntityCategoryService = customEntityCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categoriesDto = await _customEntityCategoryService.GetGroups();
            var categories = Mappings.Mapper.MapToCustomEntityGroups(categoriesDto);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var groupDto = await _customEntityCategoryService.GetGroupById(id);
            var group = Mappings.Mapper.MapToCustomTemplates(groupDto);
            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomEntityGroupModel customEntityGroupModel)
        {
            var groupDto = Mappings.Mapper.MapToTemplateGroup(customEntityGroupModel);
            var res = await _customEntityCategoryService.AddGroup(groupDto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] CustomEntityGroupModel customEntityGroupModel)
        {
            var groupDto = Mappings.Mapper.MapToTemplateGroup(customEntityGroupModel);
            var res = await _customEntityCategoryService.UpdateGroup(groupDto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _customEntityCategoryService.DeleteGroup(id);
            return Ok(response);
        }
    }
}
