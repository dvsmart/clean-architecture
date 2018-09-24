using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateFormValueController : ControllerBase
    {
        private readonly ITemplateFormValueService _customFieldValueService;

        public TemplateFormValueController(ITemplateFormValueService customFieldValueService)
        {
            _customFieldValueService = customFieldValueService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFieldValueRequest createCustomFieldValueRequest)
        {
            if (createCustomFieldValueRequest == null || !createCustomFieldValueRequest.FieldValues.Any())
                return BadRequest();
            var customFieldValueDto = new List<Domain.CustomEntity.CustomFieldValue>();
            foreach (var item in createCustomFieldValueRequest.FieldValues)
            {
                customFieldValueDto.Add(new Domain.CustomEntity.CustomFieldValue
                {
                    CustomEntityInstanceId = createCustomFieldValueRequest.CustomEntityValueId,
                    CustomFieldId = item.Id,
                    Value = item.Value
                });
            }
            var res = await _customFieldValueService.Add(customFieldValueDto);
            return Ok(res);
        }

    }
}
