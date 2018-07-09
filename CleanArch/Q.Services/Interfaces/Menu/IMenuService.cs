namespace Q.Services.Interfaces
{
    using Q.Domain.Menu;
    using Q.Services.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMenuService : IGenericService
    {
        System.Threading.Tasks.Task Add(MenuItem entity);

        System.Threading.Tasks.Task Update(MenuItem entity);

        System.Threading.Tasks.Task Delete(MenuItem entity);

        Task<IEnumerable<MenuItem>> GetAll();
    }
}
