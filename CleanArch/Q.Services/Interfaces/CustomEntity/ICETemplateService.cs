using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ICETemplateService
    {
        Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplates();

        Task<SaveResponseDto> AddTemplate(Domain.CustomEntity.CustomEntity customEntity);

        Task<SaveResponseDto> UpdateTemplate(Domain.CustomEntity.CustomEntity customEntity);

        Task<SaveResponseDto> DeleteTemplate(int id);

        Task<CustomEntityDefintionDto> GetTemplateByIdAsync(int id);

        Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplateByGroupId(int groupId);

        Task<CustomEntityTemplate> GetTemplateBasicInformationByIdAsync(int id);

    }
}
