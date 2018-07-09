using Q.Infrastructure;
using Q.Services.Interfaces.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Task
{
    public class TaskStatusService : ITaskStatusService
    {
        private readonly IRepository<Domain.Task.TaskStatus> _taskStatusRepository;

        public TaskStatusService(IRepository<Domain.Task.TaskStatus> taskStatusRepository)
        {
            _taskStatusRepository = taskStatusRepository;
        }

        public async Task<IEnumerable<Domain.Task.TaskStatus>> List()
        {
            return await _taskStatusRepository.GetAll();
        }
    }
}
