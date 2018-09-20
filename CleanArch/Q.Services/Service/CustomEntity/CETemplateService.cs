using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.CustomEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Services.Service.CustomEntity
{
    public class CETemplateService : ICETemplateService
    {
        private readonly IRepository<Domain.CustomEntity.CustomEntity> _customTemplateRepository;
        private readonly IRepository<CustomEntityGroup> _customGroupRepository;

        public CETemplateService(IRepository<Domain.CustomEntity.CustomEntity> customTemplateRepository, IRepository<CustomEntityGroup> customGroupRepository)
        {
            _customTemplateRepository = customTemplateRepository;
            _customGroupRepository = customGroupRepository;
        }
        public async Task<SaveResponseDto> AddTemplate(Domain.CustomEntity.CustomEntity customEntity)
        {
            var res = await _customTemplateRepository.Insert(customEntity);
            return new SaveResponseDto
            {
                SaveSuccessful = res,
                SavedEntityId = customEntity.Id
            };
        }

        public async Task<SaveResponseDto> DeleteTemplate(int id)
        {
            var ceGroup = await _customTemplateRepository.Get(id);
            var response = await _customTemplateRepository.Remove(ceGroup);
            return new SaveResponseDto
            {
                SavedEntityId = id,
                SaveSuccessful = response
            };
        }

        public async Task<CustomEntityTemplate> GetTemplateBasicInformationByIdAsync(int id)
        {
            var ce = await _customTemplateRepository.FindById(id);
            if (ce == null) return new CustomEntityTemplate();
            return new CustomEntityTemplate
            {
                GroupName = ce.EntityGroup.Name,
                Id = ce.Id,
                TemplateName = ce.TemplateName
            };
        }

        public async Task<CustomEntityDefintionDto> GetTemplateByIdAsync(int id)
        {
            var ce = await _customTemplateRepository.FindById(id);
            if (ce == null) return new CustomEntityDefintionDto();
            var tabFields = ce.CustomTabs.Select(x => new CustomTabDto
            {
                Caption = x.Name,
                TabId = x.Id,
                SortOrder = x.SortOrder,
                IsVisible = x.IsVisible,
                CustomFields = x.CustomFields.Select(y => new CustomFieldDto
                {
                    Caption = y.FieldName,
                    SortOrder = y.SortOrder,
                    FieldId = y.Id,
                    Type = y.FieldType.Type,
                    IsVisible = y.IsVisible ?? true,
                    IsRequired = y.IsMandatory ?? false,
                })
            }).ToList();

            var customEntityRecordDto = new CustomEntityDefintionDto
            {
                Id = ce.Id,
                TemplateName = ce.TemplateName,
                CustomTabs = tabFields,
                GroupName = ce.EntityGroup.Name
            };
            return customEntityRecordDto;
        }

        public async Task<CustomEntityGroupDto> GetTemplateByGroupId(int groupId)
        {
            var templateGroupInfo = await _customGroupRepository.FindById(groupId);

            if (templateGroupInfo == null) return new CustomEntityGroupDto();

            return new CustomEntityGroupDto
            {
                Id = templateGroupInfo.Id,
                GroupName = templateGroupInfo.Name,
                CustomEntities = templateGroupInfo.CustomEntities.Select(x => new CustomEntityDto
                {
                    Id = x.Id,
                    TemplateName = x.TemplateName
                }).ToList()
            };
        }

        public async Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplates()
        {
            return await _customTemplateRepository.GetAll();
        }

        public async Task<SaveResponseDto> UpdateTemplate(Domain.CustomEntity.CustomEntity customEntity)
        {
            var res = await _customTemplateRepository.Update(customEntity);
            return new SaveResponseDto
            {
                SaveSuccessful = res,
                SavedEntityId = customEntity.Id
            };
        }
        
    }
}
