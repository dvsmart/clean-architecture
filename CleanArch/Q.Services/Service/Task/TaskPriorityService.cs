using Q.Domain;
using Q.Services.Interfaces.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Task
{
    public class TaskPriorityService : ITaskPriorityService
    {
        private readonly IGenericRepository<Domain.Task.TaskPriority> _taskPriorityRepository;

        public TaskPriorityService(IGenericRepository<Domain.Task.TaskPriority> taskPriorityRepository)
        {
            _taskPriorityRepository = taskPriorityRepository;
        }

        public async Task<IEnumerable<Domain.Task.TaskPriority>> List()
        {
            return await _taskPriorityRepository.GetAllAsync();
        }
    }
}
