using Microsoft.EntityFrameworkCore;
using Q.Domain;
using Q.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> List(bool eager = false)
        {
            return await Query(eager).ToListAsync();
        }

        public virtual IQueryable<T> Query(bool eager = false)
        {
            var query = _context.Set<T>().AsQueryable();
            if (eager)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;
        }

        public async virtual Task<T> Get(int id, bool eager = false)
        {
            return await Query(eager).SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.Set<T>().AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<bool> Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Remove(entity);
            return await SaveChanges();
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<bool> Update(T entity)
        {
            _context.Entry(entity).CurrentValues.SetValues(entity);
            return await SaveChanges();
        }

        public IQueryable<T> GetFilteredData()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<PagedResult<T>> GetAll(int page = 1,int? pageSize = 10)
        {
            return await _context.Set<T>().GetPaged(page, pageSize.Value);
        }


        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public async Task DeleteAll(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await SaveChanges();
        }
    }

    public static class Extension
    {
        public async static Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query,
                                        int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await query.CountAsync()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = page != 0 ? (page - 1) * pageSize : 0;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
