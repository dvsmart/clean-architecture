using Q.Domain;
using Q.Infrastructure;
using Q.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async System.Threading.Tasks.Task Add(T entity)
        {
            await _repository.Insert(entity);
        }

        public async System.Threading.Tasks.Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async System.Threading.Tasks.Task Update(T entity)
        {
            await _repository.Update(entity);
        }
    }
}
