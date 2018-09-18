using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.Domain.CustomEntity;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldController : ControllerBase
    {
        private readonly ICustomFieldService _customFieldService;

        public CustomFieldController(ICustomFieldService customFieldService)
        {
            _customFieldService = customFieldService;
        }

        // GET: api/CustomField
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _customFieldService.GetAll();
            return Ok(data);
        }

        // GET: api/CustomField/5
        [HttpGet("{tabId}")]
        public async Task<IActionResult> Get(int tabId)
        {
            var customFields = await _customFieldService.GetFieldsByTabId(tabId);
            var customFieldModel = new List<CustomFieldsForTab>();
            foreach (var item in customFields)
            {
                customFieldModel.Add(new CustomFieldsForTab
                {
                    FieldCaption = item.FieldName,
                    TabId = item.CustomTabId,
                    FieldTypeName = item.FieldType.Type,
                    SortOrder = item.SortOrder ?? 1,
                    TabCaption = item.CustomTab.Name,
                    Id = item.Id
                });
            }
            return Ok(customFieldModel);
        }

        // POST: api/CustomField
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomFieldRequestModel createCustomFieldRequest)
        {
            if (createCustomFieldRequest == null) return BadRequest();
            var customField = new CustomField
            {
                CustomTabId = createCustomFieldRequest.CustomTabId,
                FieldTypeId = createCustomFieldRequest.FieldTypeId,
                FieldName = createCustomFieldRequest.FieldName,
                Id = createCustomFieldRequest.Id,
                AddedBy = 1,
                AddedDate = DateTime.Now,
                IsArchived = false,
                IsDeleted = false
            };
            var response = await _customFieldService.Add(customField);
            return Ok(response);
        }

        // PUT: api/CustomField/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] CustomFieldRequestModel createCustomFieldRequest)
        {
            var customFieldDto = new CustomField
            {
                FieldName = createCustomFieldRequest.FieldName,
                CustomTabId = createCustomFieldRequest.CustomTabId,
                FieldTypeId = createCustomFieldRequest.FieldTypeId
            };
            return Ok(await _customFieldService.UpdateAsync(customFieldDto));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _customFieldService.DeleteAsync(id));
        }
    }
}
