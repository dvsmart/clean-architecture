using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.Domain.CustomEntity;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.CustomEntity;
using Q.Web.Models.CustomEntity;

namespace Q.Web.Controllers.CustomEntity
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomTabController : ControllerBase
    {
        private readonly ICustomTabService _customTabService;

        public CustomTabController(ICustomTabService customTabService)
        {
            _customTabService = customTabService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customTabs =  await _customTabService.GetAll();
            var tabs = new List<CustomTabModel>();
            foreach (var item in customTabs)
            {
                tabs.Add(new CustomTabModel
                {
                    Id = item.Id,
                    Caption = item.Name,
                    CustomFields = item.CustomFields.Select(x => new CustomFieldModel
                    {
                        Id = x.Id,
                        Name = string.Join("fieldId_",x.Id),
                        Type = x.FieldType.Type,
                        TabId = x.CustomTabId,
                        IsMandatory = x.IsMandatory ?? true,
                        Label = x.FieldName,
                        IsVisible  = x.IsVisible ?? true
                    }).ToList(),
                    CustomEntityId = item.CustomEntityId,
                    IsVisible = item.IsVisible,
                    SortOrder = item.SortOrder ?? 1
                });
            }
            return Ok(tabs);
        }

        [HttpGet("{templateId}")]
        public async Task<IActionResult> Get(int templateId)
        {
            var customTabs = await _customTabService.GetAll();
            var filterTabs = customTabs.Where(x => x.CustomEntityId == templateId);
            var tabs = new List<CustomTabModel>();
            foreach (var item in filterTabs)
            {
                tabs.Add(new CustomTabModel
                {
                    Id = item.Id,
                    Caption = item.Name,
                    CustomFields = item.CustomFields.Select(x => new CustomFieldModel
                    {
                        Id = x.Id,
                        Name = string.Concat("fieldId_", x.Id),
                        Type = x.FieldType.Type,
                        TabId = x.CustomTabId,
                        IsMandatory = x.IsMandatory ?? true,
                        Label = x.FieldName,
                        IsVisible = x.IsVisible ?? true
                    }).ToList(),
                    CustomEntityId = item.CustomEntityId,
                    IsVisible = item.IsVisible,
                    SortOrder = item.SortOrder ?? 1
                });
            }
            return Ok(tabs);
        }

        [HttpGet("{customEntityId}", Name = "GetTabsByTemplateId")]
        public async Task<IActionResult> GetTabsByTemplateId(int customEntityId)
        {
            var customTabs = await _customTabService.GetTabsById(customEntityId);
            return Ok(customTabs);
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

    }
}