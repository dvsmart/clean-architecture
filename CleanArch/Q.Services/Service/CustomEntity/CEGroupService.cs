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
    public class CEGroupService : ICEGroupService
    {
        private readonly IRepository<CustomEntityGroup> _customEntityGroupRepository;

        public CEGroupService(IRepository<CustomEntityGroup> customEntityGroupRepository)
        {
            _customEntityGroupRepository = customEntityGroupRepository;
        }
        public async Task<SaveResponseDto> AddGroup(CustomEntityGroup customEntityGroup)
        {
            var res = await _customEntityGroupRepository.Insert(customEntityGroup);
            return new SaveResponseDto
            {
                SaveSuccessful = res,
                SavedEntityId = customEntityGroup.Id
            };
        }

        public async Task<SaveResponseDto> DeleteGroup(int id)
        {
            var ceGroup = await _customEntityGroupRepository.Get(id);
            var response = await _customEntityGroupRepository.Remove(ceGroup);
            return new SaveResponseDto
            {
                SavedEntityId = id,
                SaveSuccessful = response
            };
        }

        public async Task<CustomEntityGroup> GetGroupById(int id)
        {
            return await _customEntityGroupRepository.FindById(id);
        }

        public async Task<IEnumerable<CustomEntityGroup>> GetGroups()
        {
            return await _customEntityGroupRepository.GetAll();
        }

        public async Task<SaveResponseDto> UpdateGroup(CustomEntityGroup customEntityGroup)
        {
            var res = await _customEntityGroupRepository.Update(customEntityGroup);
            return new SaveResponseDto
            {
                SaveSuccessful = res,
                SavedEntityId = customEntityGroup.Id
            };
        }
    }
}
