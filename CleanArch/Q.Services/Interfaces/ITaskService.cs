using Q.Domain;
using Q.Domain.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Domain.Task.Task>> GetTasks();

        System.Threading.Tasks.Task AddTask(Domain.Task.Task task);

        System.Threading.Tasks.Task DeleteTask(int id);

        System.Threading.Tasks.Task UpdateTask(int id,Domain.Task.Task task);

        Task<Domain.Task.Task> GetTaskById(int id);

        IEnumerable<Domain.Task.Task> GetTasksByStatus(string status);

        PagedResult<Domain.Task.Task> GetAll(int page, int? pageSize);
    }
}
