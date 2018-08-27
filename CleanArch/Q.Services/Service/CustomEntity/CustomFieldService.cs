using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.CustomEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.CustomEntity
{
    public class CustomFieldService : ICustomFieldService
    {
        private readonly IRepository<CustomField> _customFieldRepository;

        public CustomFieldService(IRepository<CustomField> customFieldRepository)
        {
            _customFieldRepository = customFieldRepository;
        }

        public async Task<SaveResponseDto> Add(CustomField customField)
        {
            return new SaveResponseDto
            {
                SaveSuccessful = await _customFieldRepository.Insert(customField),
                SavedEntityId = customField.Id
            };
        }

        public async Task<SaveResponseDto> DeleteAsync(int id)
        {
            var customField = await _customFieldRepository.FindById(id);
            return new SaveResponseDto
            {
                SaveSuccessful = await _customFieldRepository.Remove(customField),
                SavedEntityId = customField.Id
            };
        }

        public async Task<IEnumerable<CustomField>> GetAll()
        {
            return await _customFieldRepository.GetAll();
        }

        public async Task<IEnumerable<CustomField>> GetFieldsByTabId(int id)
        {
            return await _customFieldRepository.FilterList(x=>x.CustomTabId == id);
        }

        public async Task<SaveResponseDto> UpdateAsync(CustomField customField)
        {
            return new SaveResponseDto
            {
                SaveSuccessful = await _customFieldRepository.Update(customField),
                SavedEntityId = customField.Id
            };
        }
    }
}
