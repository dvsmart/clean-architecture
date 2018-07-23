using Q.Domain;
using Q.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Generic
{
    public interface IGenericService<T> where T: BaseEntity
    {
        Task<PagedResult<T>> GetAll(int page, int? pageSize);

        System.Threading.Tasks.Task DeleteAll(List<int> ids);

        System.Threading.Tasks.Task Delete(int id);

        Task<SaveResponseDto> Insert(T entity);
    }
}
