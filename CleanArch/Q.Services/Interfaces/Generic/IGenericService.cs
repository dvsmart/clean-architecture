using Q.Domain;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Generic
{
    public interface IGenericService<T> where T: BaseEntity
    {
        Task<PagedResult<T>> GetAll(int page, int? pageSize);
    }
}
