using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldValueController : ControllerBase
    {
        private readonly ICustomFieldValueService _customFieldValueService;

        public CustomFieldValueController(ICustomFieldValueService customFieldValueService)
        {
            _customFieldValueService = customFieldValueService;
        }

        //// GET: api/CustomFieldValue
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/CustomFieldValue/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/CustomFieldValue
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFieldValueRequest createCustomFieldValueRequest)
        {
            if(createCustomFieldValueRequest != null && createCustomFieldValueRequest.FieldValues.Any())
            {
                var customFieldValueDto = new List<Domain.CustomEntity.CustomFieldValue>();
                foreach (var item in createCustomFieldValueRequest.FieldValues)
                {
                    customFieldValueDto.Add(new Domain.CustomEntity.CustomFieldValue
                    {
                        CustomEntityInstanceId = createCustomFieldValueRequest.CustomEntityId,
                        CustomFieldId = item.Id,
                        Value = item.Value
                    });
                }
                var res = await _customFieldValueService.Add(customFieldValueDto);
                return Ok(res);
            }
            return BadRequest();
        }

        //// PUT: api/CustomFieldValue/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
