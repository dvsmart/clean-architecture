using Q.Domain.CustomEntity;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.CustomEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.CustomEntity
{
    public class CETemplateService : ICETemplateService
    {
        private readonly IRepository<Domain.CustomEntity.CustomEntity> _customTemplateRepository;

        public CETemplateService(IRepository<Domain.CustomEntity.CustomEntity> customTemplateRepository)
        {
            _customTemplateRepository = customTemplateRepository;
        }
        public async Task<SaveResponseDto> AddTemplate(Domain.CustomEntity.CustomEntity customEntity)
        {
            var res = await _customTemplateRepository.Insert(customEntity);
            return new SaveResponseDto
            {
                SaveSuccessful = res,
                SavedEntityId = customEntity.Id
            };
        }

        public async Task<SaveResponseDto> DeleteTemplate(int id)
        {
            var ceGroup = await _customTemplateRepository.Get(id);
            var response = await _customTemplateRepository.Remove(ceGroup);
            return new SaveResponseDto
            {
                SavedEntityId = id,
                SaveSuccessful = response
            };
        }

        public Task<Domain.CustomEntity.CustomEntity> GetTemplateById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplateByGroupId(int groupId)
        {
            return await _customTemplateRepository.FilterList(x => x.EntityGroupId == groupId && !x.IsDeleted  && !x.IsArchived);
        }

        public async Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplates()
        {
            return await _customTemplateRepository.GetAll();
        }

        public async Task<SaveResponseDto> UpdateTemplate(Domain.CustomEntity.CustomEntity customEntity)
        {
            var res = await _customTemplateRepository.Update(customEntity);
            return new SaveResponseDto
            {
                SaveSuccessful = res,
                SavedEntityId = customEntity.Id
            };
        }
        
    }
}
