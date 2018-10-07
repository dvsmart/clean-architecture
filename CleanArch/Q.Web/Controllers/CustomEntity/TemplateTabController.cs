using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Domain.CustomEntity;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateTabController : ControllerBase
    {
        private readonly ITemplateTabService _customTabService;

        public TemplateTabController(ITemplateTabService customTabService)
        {
            _customTabService = customTabService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomTabRequest customTabRequestModel)
        {
            if (customTabRequestModel == null) return BadRequest();
            var customTab = new CustomTab
            {
                CustomEntityId = customTabRequestModel.CustomEntityId,
                Name = customTabRequestModel.Caption,
                AddedBy = 1,
                AddedDate = DateTime.Now,
                Id = customTabRequestModel.Id
            };
            var response = await _customTabService.Add(customTab);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var templateTab = await _customTabService.GetById(id);
            if (templateTab == null) return BadRequest();
            var tabModel = new TemplateTabModel { TabId = templateTab.Id, TabCaption = templateTab.Name, CustomEntityId = templateTab.CustomEntityId };
            foreach (var cf in templateTab.CustomFields)
            {
                tabModel.CustomFields.Add(new CustomFieldModel
                {
                    Name = cf.FieldName,
                    Id = cf.Id,
                    SortOrder = cf.SortOrder,
                    Type = cf.FieldType.Type,
                    IsVisible = cf.IsVisible ?? true,
                    IsMandatory = cf.IsMandatory ?? false
                });
            }
            return Ok(tabModel);
        }

    }
}