using Q.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Q.Services.Interfaces
{
    public interface IMenuService
    {
        Task Add(MenuItem entity);

        Task Update(MenuItem entity);

        Task Delete(MenuItem entity);

        Task<IEnumerable<MenuItem>> GetAll();
    }
}
