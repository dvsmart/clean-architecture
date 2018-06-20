using Q.Domain.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Domain.Task.Task>> GetTasks();

        System.Threading.Tasks.Task AddTask(Domain.Task.Task task);
    }
}
