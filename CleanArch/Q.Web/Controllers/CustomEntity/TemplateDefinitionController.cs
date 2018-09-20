using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateDefinitionController : ControllerBase
    {
        private readonly ICETemplateService _customEntityService;

        public TemplateDefinitionController(ICETemplateService customEntityService)
        {
            _customEntityService = customEntityService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var data  = await _customEntityService.GetTemplates();
        //    var templateModel = new List<CustomEntityTemplateModel>();
        //    if(data != null)
        //    {
        //        foreach (var item in data)
        //        {
        //            templateModel.Add(new CustomEntityTemplateModel
        //            {
        //                GroupId = item.EntityGroupId,
        //                TemplateName = item.TemplateName,
        //                Id = item.Id,
        //                GroupName = item.EntityGroup.Name
        //            });
        //        }
        //    }
        //    return Ok(templateModel);
        //}

        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetByGroupId(int groupId)
        {
            var data = await _customEntityService.GetTemplateByGroupId(groupId);
            var templateModel = new CustomTemplateModel
            {
                GroupName = data.GroupName,
                GroupId = data.Id,
                Templates = data.CustomEntities.Select(x => new CustomEntityTemplateModel
                {
                    Id = x.Id,
                    TemplateName = x.TemplateName
                }).ToList()
            };
            return new OkObjectResult(templateModel);
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
