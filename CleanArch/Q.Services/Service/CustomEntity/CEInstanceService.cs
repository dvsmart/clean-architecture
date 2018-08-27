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

        public CEInstanceService(
            IRepository<CustomEntityInstance> customEntityInstanceRepository,
            IRepository<CustomTab> customTabRepository,
            IRepository<CustomField> customFieldRepository,
            IRepository<CustomFieldValue> customFieldValueRepository
            )
        {
            _customEntityInstanceRepository = customEntityInstanceRepository;
            _customTabRepository = customTabRepository;
            _customFieldRepository = customFieldRepository;
            _customFieldValueRepository = customFieldValueRepository;
        }

        public async Task<SaveResponseDto> Add(CustomEntityInstance customEntityInstance)
        {
            try
            {
                var id = _customEntityInstanceRepository.LatestRecordId() ?? 1;
                customEntityInstance.InstanceId = Helper.DataIdGenerationService.GenerateDataId(id, "CE");
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
                SavedDataId = customEntityInstance.InstanceId
            };
        }

        public async Task<IEnumerable<CustomEntityInstance>> GetAll()
        {
            return await _customEntityInstanceRepository.GetAll();
        }

        public async Task<CustomEntityRecordDto> GetById(int id)
        {
            var customInstance = await _customEntityInstanceRepository.FindById(id);
            var instanceTabs = _customTabRepository.FindBy(x=>x.CustomEntityId == customInstance.TemplateId);

            var tabFields = instanceTabs.Select(x => new CustomTabDto
            {
                Caption = x.Name,
                TabId = x.Id,
                SortOrder = x.SortOrder,
                CustomFields = x.CustomFields.Select(y => new CustomFieldDto
                {
                    Caption = y.FieldName,
                    SortOrder = y.SortOrder,
                    FieldId = y.Id,
                    FieldType = y.FieldType.Type
                }).ToList()
            }).ToList();

            var customEntityRecordDto = new CustomEntityRecordDto
            {
                CustomEntityId = customInstance.TemplateId,
                DataId = customInstance.InstanceId,
                Id = customInstance.Id,
                CustomTabs = tabFields
            };
            return customEntityRecordDto;
        }
    }
}
