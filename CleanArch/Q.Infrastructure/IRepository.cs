using Q.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Q.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Remove(T entity);
        Task SaveChanges();

        Task<T> Get(int id, bool eager = false);

        Task<IEnumerable<T>> List(bool eager = false);

        IQueryable<T> GetFilteredData();

        Task<PagedResult<T>> GetAll(int page = 1, int? pageSize = 10);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task DeleteAll(List<T> entities);
    }
}
