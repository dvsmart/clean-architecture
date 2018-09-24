using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _customEntityService;

        public TemplateController(ITemplateService customEntityService)
        {
            _customEntityService = customEntityService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomTemplateRequest customEntityTemplateModel)
        {
            var templateDto = Mappings.Mapper.MapToCustomEntityDto(customEntityTemplateModel);
            var res = await _customEntityService.AddTemplate(templateDto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] CreateCustomTemplateRequest customEntityTemplateModel)
        {
            var templateDto = Mappings.Mapper.MapToCustomEntityDto(customEntityTemplateModel);
            var res = await _customEntityService.UpdateTemplate(templateDto);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateDefinition(int id)
        {
            var response = await _customEntityService.GetTemplateByIdAsync(id);
            return Ok(response);
        }

    }
}
