using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.CustomEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Q.Services.Service.CustomEntity
{
    public class CustomTabService : ICustomTabService
    {
        private readonly IRepository<CustomTab> _customTabRepository;

        public CustomTabService(IRepository<CustomTab> customTabRepository)
        {
            _customTabRepository = customTabRepository;
        }

        public async Task<SaveResponseDto> Add(CustomTab customTab)
        {
            return new SaveResponseDto
            {
                SaveSuccessful = await _customTabRepository.Insert(customTab),
                SavedEntityId = customTab.Id
            };
        }

        public async Task<SaveResponseDto> Delete(int id)
        {
            var customTab = await _customTabRepository.FindById(id);
            return new SaveResponseDto
            {
                SaveSuccessful = await _customTabRepository.Remove(customTab),
                SavedEntityId = customTab.Id
            };
        }

        public async Task<IEnumerable<CustomTab>> GetAll()
        {
            return await _customTabRepository.GetAll();
        }

        public async Task<CustomTab> GetById(int id)
        {
            return await _customTabRepository.FindById(id);
        }

        public async Task<SaveResponseDto> UpdateAsync(CustomTab customTab)
        {
            return new SaveResponseDto
            {
                SaveSuccessful = await _customTabRepository.Update(customTab),
                SavedEntityId = customTab.Id
            };
        }
        
    }
}
