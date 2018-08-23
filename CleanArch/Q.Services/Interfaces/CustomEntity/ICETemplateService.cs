using Q.Domain.Response;
using System.Collections.Generic;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ICETemplateService
    {
        System.Threading.Tasks.Task<IEnumerable<Domain.CustomEntity.CustomEntity>> GetTemplates();

        System.Threading.Tasks.Task<SaveResponseDto> AddTemplate(Domain.CustomEntity.CustomEntity customEntity);

        System.Threading.Tasks.Task<SaveResponseDto> UpdateTemplate(Domain.CustomEntity.CustomEntity customEntity);

        System.Threading.Tasks.Task<SaveResponseDto> DeleteTemplate(int id);

        System.Threading.Tasks.Task<Domain.CustomEntity.CustomEntity> GetTemplateById(int id);

    }
}
