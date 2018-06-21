using Q.Infrastructure;
using Q.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Task
{
    public class TaskPriorityService : ITaskPriorityService
    {
        private readonly IRepository<Domain.Task.TaskPriority> _taskPriorityRepository;

        public TaskPriorityService(IRepository<Domain.Task.TaskPriority> taskPriorityRepository)
        {
            _taskPriorityRepository = taskPriorityRepository;
        }

        public async Task<IEnumerable<Domain.Task.TaskPriority>> List()
        {
            return await _taskPriorityRepository.GetAll();
        }
    }
}
