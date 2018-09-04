using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomEntityTemplateController : ControllerBase
    {

        private readonly ICETemplateService _customEntityTemplateService;
        private readonly IOutputConverter _outputConverter;

        public CustomEntityTemplateController(ICETemplateService customEntityTemplateService, IOutputConverter outputConverter)
        {
            _customEntityTemplateService = customEntityTemplateService;
            _outputConverter = outputConverter;
        }
        // GET: api/Template
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var templatesDto = await _customEntityTemplateService.GetTemplates();
            var templates = Mappings.Mapper.MaptoCustomTemplates(templatesDto);
            return Ok(templates);
        }


        // POST: api/Template
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomTemplateRequest customEntityTemplateModel)
        {
            var templateDto = Mappings.Mapper.MapToCustomEntityDto(customEntityTemplateModel);
            var res = await _customEntityTemplateService.AddTemplate(templateDto);
            return Ok(res);
        }

        // PUT: api/Template/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] CreateCustomTemplateRequest customEntityTemplateModel)
        {
            var templateDto = Mappings.Mapper.MapToCustomEntityDto(customEntityTemplateModel);
            var res = await _customEntityTemplateService.UpdateTemplate(templateDto);
            return Ok(res);
        }

    }
}
