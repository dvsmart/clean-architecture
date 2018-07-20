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

        public async Task Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Remove(entity);
            await SaveChanges();
        }

        public async Task<T> Get(long id)
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

        public async Task Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.Set<T>().AddAsync(entity);
            await SaveChanges();
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public IQueryable<T> GetFilteredData()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<PagedResult<T>> GetAll(int page = 1,int? pageSize = 10)
        {
            return await _context.Set<T>().GetPaged(page, pageSize.Value);
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
