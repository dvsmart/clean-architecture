using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ICEInstanceService
    {
        Task<SaveResponseDto> Add(CustomEntityInstance customEntityInstance);

        Task<IEnumerable<CustomEntityInstance>> GetAll(int templateId);

        Task<CustomEntityRecordDto> GetById(int id);

    }
}
