using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Helpers;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomEntityInstanceController : ControllerBase
    {
        private readonly ICEInstanceService _customEntityInstanceService;

        public CustomEntityInstanceController(ICEInstanceService customEntityInstanceService)
        {
            _customEntityInstanceService = customEntityInstanceService;
        }

        //GET: api/CustomEntityInstance
        [HttpGet]
        public async Task<IActionResult> GetList(int templateId, int page, int? pageSize)
        {
            var data = await _customEntityInstanceService.GetAll(templateId, page, pageSize);
            if (data != null)
            {
                var cevRecords = data.Results != null ? Mappings.Mapper.MapToCustomEntityValueGridModel(data.Results) : null;
                var result = cevRecords.GetPagedResult(data.PageSize, data.CurrentPage, data.RowCount);
                return new OkObjectResult(result);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _customEntityInstanceService.GetById(id);
            return Ok(response);
        }

        // POST: api/CustomEntityInstance
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomEntityInstanceModel customEntityInstanceModel)
        {
            var customInstanceDto = new Domain.CustomEntity.CustomEntityInstance
            {
                Id = customEntityInstanceModel.Id,
                CustomEntityId = customEntityInstanceModel.CustomEntityId,
                AddedDate = DateTime.Now,
                AddedBy = 1,
                Status = 1,
                DueDate = DateTime.Now.AddDays(2),
                IsDeleted = false,
                IsArchived = false
            };
            var response = await _customEntityInstanceService.Add(customInstanceDto);
            return Ok(response);
        }
     

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _customEntityInstanceService.Delete(id));
        }
    }
}
