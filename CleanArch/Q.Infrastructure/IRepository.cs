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
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);

        Task<bool> Remove(T entity);
        Task<bool> SaveChanges();

        Task<T> Get(int id, bool eager = false);

        Task<IEnumerable<T>> List(bool eager = false);

        IQueryable<T> GetFilteredData();

        Task<PagedResult<T>> GetAll(int page = 1, int? pageSize = 10);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task DeleteAll(List<T> entities);

        int? LatestRecordId();

        Task<T> FindById(int id);

        Task<IEnumerable<T>> FilterList(Expression<Func<T, bool>> predicate);
    }
}
