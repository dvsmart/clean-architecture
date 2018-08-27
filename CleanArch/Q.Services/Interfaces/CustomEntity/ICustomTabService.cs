using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ICustomTabService
    {
        Task<IEnumerable<CustomTab>> GetAll();

        Task<SaveResponseDto> Add(CustomTab customTab);

        Task<SaveResponseDto> UpdateAsync(CustomTab customTab);

        Task<SaveResponseDto> Delete(int id);

        Task<CustomTab> GetById(int id);

    }
}
