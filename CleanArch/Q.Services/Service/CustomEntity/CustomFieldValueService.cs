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
            if (customFieldValues.Any())
            {
                foreach (var item in customFieldValues)
                {
                    response = await _customFieldValueRepository.Insert(item);
                }
                return new SaveResponseDto
                {
                    SaveSuccessful = response,
                };
            }
            return new SaveResponseDto
            {
                SaveSuccessful = response
            };
        }
    }
}
