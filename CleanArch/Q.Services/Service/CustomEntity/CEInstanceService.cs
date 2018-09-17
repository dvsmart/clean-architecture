using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Q.Domain;
using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.CustomEntity;


namespace Q.Services.Service.CustomEntity
{
    public class CEInstanceService : ICEInstanceService
    {
        private readonly IRepository<CustomEntityInstance> _customEntityInstanceRepository;
        private readonly IRepository<CustomTab> _customTabRepository;
        private readonly IRepository<CustomField> _customFieldRepository;
        private readonly IRepository<CustomFieldValue> _customFieldValueRepository;
        private readonly IRepository<Domain.CustomEntity.CustomEntity> _customEntityRepository;

        public CEInstanceService(
            IRepository<CustomEntityInstance> customEntityInstanceRepository,
            IRepository<CustomTab> customTabRepository,
            IRepository<CustomField> customFieldRepository,
            IRepository<CustomFieldValue> customFieldValueRepository,
            IRepository<Domain.CustomEntity.CustomEntity> customEntityRepository
            )
        {
            _customEntityInstanceRepository = customEntityInstanceRepository;
            _customTabRepository = customTabRepository;
            _customFieldRepository = customFieldRepository;
            _customFieldValueRepository = customFieldValueRepository;
            _customEntityRepository = customEntityRepository;
        }

        public async Task<SaveResponseDto> Add(CustomEntityInstance customEntityInstance)
        {
            try
            {
                var id = _customEntityInstanceRepository.LatestRecordId() ?? 1;
                customEntityInstance.DataId = Helper.DataIdGenerationService.GenerateDataId(id, "CE");
            }
            catch (System.Exception ex)
            {
                return new SaveResponseDto
                {
                    SaveSuccessful = false,
                    ErrorMessage = ex.Message,
                };
            }
            var response = await _customEntityInstanceRepository.Insert(customEntityInstance);
            return new SaveResponseDto
            {
                SaveSuccessful = response,
                RecordId = customEntityInstance.Id,
                SavedDataId = customEntityInstance.DataId,
                SavedEntityId = customEntityInstance.CustomEntityId
            };
        }

        public async Task<PagedResult<CustomEntityInstance>> GetAll(int templateId, int page, int? pageSize)
        {
            return await _customEntityInstanceRepository.FilterList(x => x.CustomEntityId == templateId, page, pageSize);
        }

        public async Task<CustomEntityRecordDto> GetById(int id)
        {
            var customInstance = await _customEntityInstanceRepository.FindById(id);
            if (customInstance == null) return new CustomEntityRecordDto();
            var customfields = new List<CustomFieldDto>();
            var customTabFields = customInstance.CustomEntity?.CustomTabs.Select(x => new CustomTabDto
            {
                Caption = x.Name,
                TabId = x.Id,
                SortOrder = x.SortOrder,
                IsVisible = x.IsVisible,
                CustomFields = customInstance.CustomFieldValues.Any() ? customInstance.CustomFieldValues.Where(y => y.CustomField.CustomTabId == x.Id).Select(cfv => new CustomFieldDto
                {
                    FieldId = cfv.CustomFieldId,
                    Caption = cfv.CustomField.FieldName,
                    IsVisible = cfv.CustomField.IsVisible ?? true,
                    IsRequired = cfv.CustomField.IsMandatory ?? false,
                    SortOrder = cfv.CustomField.SortOrder,
                    Type = cfv.CustomField.FieldType.Type,
                    Value = cfv.Value,
                }) : customInstance.CustomEntity.CustomTabs.Where(t => t.Id == x.Id).SelectMany(ct => ct.CustomFields).Select(cf => new CustomFieldDto
                {
                    FieldId = cf.Id,
                    Caption = cf.FieldName,
                    IsVisible = cf.IsVisible ?? true,
                    IsRequired = cf.IsMandatory ?? false,
                    SortOrder = cf.SortOrder,
                    Type = cf.FieldType.Type,
                    Value = cf.DefaultValue
                })
            }).ToList();
            return new CustomEntityRecordDto
            {
                CustomEntityId = customInstance.CustomEntityId,
                TemplateName = customInstance.CustomEntity.TemplateName,
                DataId = customInstance.DataId,
                Id = customInstance.Id,
                CustomTabs = customTabFields
            };
        }

        public async Task<SaveResponseDto> Delete(int id)
        {
            var record = await _customEntityInstanceRepository.FindById(id);
            var response =  await _customEntityInstanceRepository.Remove(record);
            return new SaveResponseDto
            {
                SaveSuccessful = response,
                SavedEntityId = id,
                SavedDataId = record.DataId
            };
        }
    }
}
