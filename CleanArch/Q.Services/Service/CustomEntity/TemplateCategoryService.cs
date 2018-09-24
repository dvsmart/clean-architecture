using Q.Domain;
using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.CustomEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.Services.Service.CustomEntity
{
    public class TemplateCategoryService : ITemplateCategoryService
    {
        private readonly IGenericRepository<CustomEntityGroup> _customEntityGroupRepository;

        public TemplateCategoryService(IGenericRepository<CustomEntityGroup> customEntityGroupRepository)
        {
            _customEntityGroupRepository = customEntityGroupRepository;
        }
        public async Task<SaveResponseDto> AddGroup(CustomEntityGroup customEntityGroup)
        {
            var res = await _customEntityGroupRepository.AddAsync(customEntityGroup);
            return new SaveResponseDto
            {
                SaveSuccessful = res != null,
                SavedEntityId = customEntityGroup.Id
            };
        }

        public async Task<SaveResponseDto> DeleteGroup(int id)
        {
            var ceGroup = await _customEntityGroupRepository.FindAsync(x => x.Id == id);
            var response = await _customEntityGroupRepository.DeleteAsync(ceGroup);
            return new SaveResponseDto
            {
                SavedEntityId = id,
                SaveSuccessful = response != default(int)
            };
        }

        public async Task<CustomEntityGroup> GetGroupById(int id)
        {
            return await _customEntityGroupRepository.FindAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CustomEntityGroup>> GetGroups()
        {
            return await _customEntityGroupRepository.GetAllAsync();
        }


        public async Task<SaveResponseDto> UpdateGroup(CustomEntityGroup customEntityGroup)
        {
            var res = await _customEntityGroupRepository.UpdateAsync(customEntityGroup, customEntityGroup.Id);
            return new SaveResponseDto
            {
                SaveSuccessful = res != null,
                SavedEntityId = customEntityGroup.Id
            };
        }
    }
}
