namespace Q.Services.Interfaces
{
    using Q.Domain.Menu;
    using Q.Services.Interfaces.Generic;
    using System.Collections.Generic;

    public interface IMenuService
    {
        System.Threading.Tasks.Task Add(MenuItem entity);

        System.Threading.Tasks.Task Update(MenuItem entity);

        System.Threading.Tasks.Task Delete(MenuItem entity);

        System.Threading.Tasks.Task<IEnumerable<MenuItem>> GetAll();
    }
}
