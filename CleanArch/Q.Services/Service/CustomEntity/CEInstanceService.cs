using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                SavedDataId = customEntityInstance.DataId
            };
        }

        public async Task<IEnumerable<CustomEntityInstance>> GetAll(int templateId)
        {
            return await _customEntityInstanceRepository.FilterList(x => x.CustomEntityId == templateId);
        }

        public async Task<CustomEntityRecordDto> GetById(int id)
        {
            var customInstance = await _customEntityInstanceRepository.FindById(id);
            if (customInstance == null) return new CustomEntityRecordDto();
            var instanceTabs = _customTabRepository.FindBy(x => x.CustomEntityId == customInstance.CustomEntityId);
            List<CustomTabDto> tabFields;
            if (instanceTabs == null)
            {
                tabFields = new List<CustomTabDto>();
            }
            else
            {
                tabFields = instanceTabs.Select(x => new CustomTabDto
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
                        Value = y.CustomFieldValues.FirstOrDefault(z => z.CustomFieldId == y.Id).Value
                    }).ToList()
                }).ToList();
            }
            return new CustomEntityRecordDto
            {
                CustomEntityId = customInstance.CustomEntityId,
                DataId = customInstance.DataId,
                Id = customInstance.Id,
                CustomTabs = tabFields
            };
        }

    }
}
