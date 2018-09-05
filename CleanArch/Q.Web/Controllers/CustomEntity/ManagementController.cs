using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.Services.Interfaces.CustomEntity;

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
    }

    public class CustomEntityManagement
    {
         public List<Group> Groups { get; set; }
    }


    public class Group
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public List<Template> Templates { get; set; }

    }

    public class Template
    {
        public int TemplateId { get; set; }

        public string TemplateName { get; set; }

        public List<Tab> Tabs { get; set; }
    }

    public class Tab
    {
        public int TabId { get; set; }

        public string TabName { get; set; }

        public List<Field> Fields { get; set; }

    }

    public class Field
    {
        public int FieldId { get; set; }

        public string  Caption { get; set; }
    }

}
