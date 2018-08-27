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
    public class CustomEntityInstanceController : ControllerBase
    {
        private readonly ICEInstanceService _customEntityInstanceService;

        public CustomEntityInstanceController(ICEInstanceService customEntityInstanceService)
        {
            _customEntityInstanceService = customEntityInstanceService;
        }

        //GET: api/CustomEntityInstance
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data  = await _customEntityInstanceService.GetAll();
            var recordModel = new List<CustomEntityInstanceGridModel>();
            if(data != null)
            {
                foreach (var item in data)
                {
                    recordModel.Add(new CustomEntityInstanceGridModel
                    {
                        Id = item.Id,
                        AddedOn = item.AddedDate,
                        DataId = item.InstanceId,
                        DueDate = item.DueDate ?? DateTime.Now.AddDays(5),
                        Status = item.Status == 1 ? "Draft" : "Published"
                    });
                }
            }
            return Ok(recordModel);
        }

        // GET: api/CustomEntityInstance/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
                TemplateId = customEntityInstanceModel.CustomEntityId,
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

        //// PUT: api/CustomEntityInstance/5
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
