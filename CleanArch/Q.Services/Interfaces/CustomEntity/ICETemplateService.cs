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

        Task<Domain.CustomEntity.CustomEntity> GetTemplateById(int id);

        Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplateByGroupId(int groupId);

    }
}
