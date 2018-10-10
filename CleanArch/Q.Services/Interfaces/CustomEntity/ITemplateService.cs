using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Q.Dtos.CustomEntity;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ITemplateService
    {
        Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplates();

        Task<SaveResponseDto> AddTemplate(Domain.CustomEntity.CustomEntity customEntity);

        Task<SaveResponseDto> UpdateTemplate(Domain.CustomEntity.CustomEntity customEntity);

        Task<SaveResponseDto> DeleteTemplate(int id);

        Task<CustomEntityDefintionDto> GetTemplateByIdAsync(int id);

        Task<CustomEntityGroupDto> GetTemplateByGroupId(int groupId);

        Task<CustomEntityTemplate> GetTemplateBasicInformationByIdAsync(int id);

    }
}
