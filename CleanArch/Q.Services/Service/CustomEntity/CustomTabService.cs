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
    public class CustomTabService : ICustomTabService
    {
        private readonly IRepository<CustomTab> _customTabRepository;
        private readonly IRepository<Domain.CustomEntity.CustomEntity> _customEntityRepository;


        public CustomTabService(IRepository<CustomTab> customTabRepository, IRepository<Domain.CustomEntity.CustomEntity> customEntityRepository)
        {
            _customTabRepository = customTabRepository;
            _customEntityRepository = customEntityRepository;
        }

        public async Task<SaveResponseDto> Add(CustomTab customTab)
        {
            return new SaveResponseDto
            {
                SaveSuccessful = await _customTabRepository.Insert(customTab),
                RecordId = customTab.Id
            };
        }

        public async Task<SaveResponseDto> Delete(int id)
        {
            var customTab = await _customTabRepository.FindById(id);
            return new SaveResponseDto
            {
                SaveSuccessful = await _customTabRepository.Remove(customTab),
                RecordId = customTab.Id
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

        public async Task<CustomTemplateTabDto> GetTabsById(int id)
        {
            var ce = await _customEntityRepository.FindById(id);
            var tabDto = new CustomTemplateTabDto();
            if (ce == null) return tabDto;

            if (ce.CustomTabs.Any())
            {
                tabDto.CustomTabs = ce.CustomTabs?.Select(x => new CustomTabResponseDto
                {
                    FieldsCount = x.CustomFields.Count,
                    Id = x.Id,
                    TabName = x.Name
                }).ToList();
            }
            tabDto.CustomEntityId = ce.Id;
            return tabDto;
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
