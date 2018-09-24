using System.Linq;
using System.Threading.Tasks;
using Q.Domain;
using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Services.Interfaces.CustomEntity;


namespace Q.Services.Service.CustomEntity
{
    public class TemplateFormRecordService : ITemplateFormRecordService
    {
        private readonly IGenericRepository<CustomEntityInstance> _customEntityInstanceRepository;

        public TemplateFormRecordService(IGenericRepository<CustomEntityInstance> customEntityInstanceRepository)
        {
            _customEntityInstanceRepository = customEntityInstanceRepository;
        }

        public async Task<SaveResponseDto> Add(CustomEntityInstance customEntityInstance)
        {
            try
            {
                var id = _customEntityInstanceRepository.GetLast().Id;
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
            var response = await _customEntityInstanceRepository.AddAsync(customEntityInstance);
            return new SaveResponseDto
            {
                SaveSuccessful = response != null,
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
            var customInstance = await _customEntityInstanceRepository.FindAsync(x => x.Id == id);
            if (customInstance == null) return new CustomEntityRecordDto();
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
                TemplateName = customInstance.CustomEntity?.TemplateName,
                DataId = customInstance.DataId,
                Id = customInstance.Id,
                CustomTabs = customTabFields
            };
        }

        public async Task<SaveResponseDto> Delete(int id)
        {
            var record = await _customEntityInstanceRepository.FindAsync(x=>x.Id == id);
            var response =  await _customEntityInstanceRepository.DeleteAsync(record);
            return new SaveResponseDto
            {
                SaveSuccessful = response != default(int),
                SavedEntityId = id,
                SavedDataId = record.DataId
            };
        }
    }
}
