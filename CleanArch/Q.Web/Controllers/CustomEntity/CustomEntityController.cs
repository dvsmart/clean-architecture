using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomEntityController : ControllerBase
    {
        private readonly ICETemplateService _customEntityService;

        public CustomEntityController(ICETemplateService customEntityService)
        {
            _customEntityService = customEntityService;
        }

        //GET: api/CustomEntity
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data  = await _customEntityService.GetTemplates();
            var templateModel = new List<CustomEntityTemplateModel>();
            if(data != null)
            {
                foreach (var item in data)
                {
                    templateModel.Add(new CustomEntityTemplateModel
                    {
                        GroupId = item.EntityGroupId,
                        TemplateName = item.TemplateName,
                        Id = item.Id,
                        GroupName = item.EntityGroup.Name
                    });
                }
            }
            return Ok(templateModel);
        }

        //GET: api/CustomEntity/5
        [HttpGet("{id}", Name = "GetByTemplateId")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _customEntityService.GetTemplateByIdAsync(id);
            return Ok(response);
        }

        // POST: api/CustomEntity
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomEntityTemplateModel customEntityModel)
        {
            var customInstanceDto = new Domain.CustomEntity.CustomEntity
            {
                Id = customEntityModel.Id,
                TemplateName = customEntityModel.TemplateName,
                EntityGroupId = customEntityModel.GroupId,
                IsDeleted = false,
                IsArchived = false
            };
            var response = await _customEntityService.AddTemplate(customInstanceDto);
            return Ok(response);
        }

    }
}
