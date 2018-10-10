﻿using Q.Dtos.CustomEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Settings.CustomEntityManagement
{
    public interface ICustomEntityManagementService
    {
        Task<List<CustomGroupDto>> GetCustomGroups();

        Task<CustomGroupTemplateDto> GetCustomTemplates(int groupId);

        Task<CustomTemplateTabDto> GetCustomTemplateTabs(int templateId);

        Task<List<CustomTabFieldResponseDto>> GetCustomTabFields(int tabId);

        Task<CustomDto> AddCustomGroup(CreateCustomGroupDto createCustomGroupRequest);

        Task<CustomDto> AddCustomTemplate(CreateCustomTemplateRequest createCustomTemplateRequest);

        Task<CustomDto> AddCustomTemplateTab(CreateCustomTemplateTabRequest createCustomTemplateTabRequest);

        Task<CustomDto> AddCustomTemplateTabFields(CreateCustomTabFieldRequest createCustomTabFieldRequest);
    }
}
