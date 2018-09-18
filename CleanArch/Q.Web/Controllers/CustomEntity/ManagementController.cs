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
    public class ManagementController : ControllerBase
    {
        private readonly ICETemplateService _templateService;
        private readonly ICEGroupService _groupService;
        private readonly ICustomTabService _tabService;
        private readonly ICustomFieldService _fieldService;

        public ManagementController(ICEGroupService groupService,ICETemplateService templateService,ICustomTabService tabService,ICustomFieldService fieldService)
        {
            _groupService = groupService;
            _templateService = templateService;
            _tabService = tabService;
            _fieldService = fieldService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await _groupService.GetGroups();
            if (groups == null) return new NotFoundResult();
            var model = groups.Select(x => new Group
            {
                GroupId = x.Id,
                Name = x.Name,
                Templates = x.CustomEntities.Select(t => new Template
                {
                    TemplateId = t.Id,
                    TemplateName = t.TemplateName,
                    Tabs = t.CustomTabs.Select(ct=> new Tab
                    {
                        TabId = ct.Id,
                        TabName = ct.Name,
                        Fields = ct.CustomFields.Select(f=> new Field
                        {
                            FieldId = f.Id,
                            Caption = f.FieldName
                        }).ToList()
                    }).ToList()
                }).ToList()
            }).ToList();
            var managementModel = new CustomEntityManagement
            {
                Groups = model
            };
            return Ok(managementModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTab([FromBody]CreateCustomTabRequest tabRequest)
        {
            var customTab = new Domain.CustomEntity.CustomTab
            {
                CustomEntityId = tabRequest.CustomEntityId,
                Name = tabRequest.Caption,
                Id = tabRequest.Id,
                AddedDate = DateTime.Now,
                AddedBy = 1,
                IsVisible = true,
                SortOrder = 1
            };

            var response = await _tabService.Add(customTab);
            return new OkObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateField([FromBody]CustomFieldRequestModel fieldRequest)
        {
            var customField = new Domain.CustomEntity.CustomField
            {
                FieldName = fieldRequest.FieldName,
                FieldTypeId = fieldRequest.FieldTypeId,
                CustomTabId = fieldRequest.CustomTabId,
                Id = fieldRequest.Id,
                AddedDate = DateTime.Now,
                AddedBy = 1,
                IsVisible = true,
                SortOrder = 1
            };

            var response = await _fieldService.Add(customField);
            return new OkObjectResult(response);
        }
    }


    

}
