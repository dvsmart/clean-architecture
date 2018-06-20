using Q.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Q.Services.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<IEnumerable<T>> GetAll();
    }
}
