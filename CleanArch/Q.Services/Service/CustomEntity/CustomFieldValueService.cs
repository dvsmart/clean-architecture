using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.CustomEntity;

namespace Q.Services.Service.CustomEntity
{
    public class CustomFieldValueService : ICustomFieldValueService
    {
        private readonly IRepository<CustomFieldValue> _customFieldValueRepository;

        public CustomFieldValueService(IRepository<CustomFieldValue> customFieldValueRepository)
        {
            _customFieldValueRepository = customFieldValueRepository;
        }

        public async Task<SaveResponseDto> Add(List<CustomFieldValue> customFieldValues)
        {
            bool response = false;
            var existingFieldValues = _customFieldValueRepository.FindBy(x => x.CustomEntityInstanceId == customFieldValues.FirstOrDefault().CustomEntityInstanceId);
            if (existingFieldValues.Any())
            {
                foreach (var item in existingFieldValues)
                {
                    if(customFieldValues.Any(x => x.CustomFieldId == item.CustomFieldId))
                    {
                        foreach (var field in customFieldValues.Where(x => x.CustomFieldId == item.CustomFieldId))
                        {
                            item.Value = field.Value;
                        }
                        response = await _customFieldValueRepository.Update(item);
                    }
                    else
                    {
                        foreach (var newItem in customFieldValues.Where(x=>x.CustomFieldId == item.CustomFieldId))
                        {
                            response = await _customFieldValueRepository.Insert(newItem);
                        }
                    }
                }
            }
            foreach (var item in customFieldValues)
            {
                response = await _customFieldValueRepository.Insert(item);
            }

            return new SaveResponseDto
            {
                SaveSuccessful = response
            };
        }
    }
}
