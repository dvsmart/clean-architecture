using Q.Domain;
using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Threading.Tasks;
using Q.Dtos.CustomEntity;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ITemplateFormRecordService
    {
        Task<SaveResponseDto> Add(CustomEntityInstance customEntityInstance);

        Task<PagedResult<CustomEntityInstance>> GetAll(int templateId, int page, int? pageSize);

        Task<CustomEntityRecordDto> GetById(int id);

        Task<SaveResponseDto> Delete(int id);

    }
}
