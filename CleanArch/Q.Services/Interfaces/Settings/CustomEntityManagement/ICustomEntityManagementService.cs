using Q.Dtos.CustomEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Services.Interfaces.Settings.CustomEntityManagement
{
    public interface ICustomEntityManagementService
    {
        CustomGroupDto GetCustomGroups();

        List<CustomTemplateDto> GetCustomTemplates(int groupId);

        CustomTemplateTabDto GetCustomTemplateTabs(int templateId);


    }
}
