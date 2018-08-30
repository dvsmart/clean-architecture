using Q.Domain;
using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ICEInstanceService
    {
        Task<SaveResponseDto> Add(CustomEntityInstance customEntityInstance);

        Task<PagedResult<CustomEntityInstance>> GetAll(int templateId, int page, int? pageSize);

        Task<CustomEntityRecordDto> GetById(int id);

    }
}
