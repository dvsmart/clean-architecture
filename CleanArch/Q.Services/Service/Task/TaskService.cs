using Q.Domain.Task;
using Q.Infrastructure;
using Q.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Q.Services.Service.Task
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Domain.Task.Task> _taskRepository;

        public TaskService(IRepository<Domain.Task.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task AddTask(Domain.Task.Task task)
        {
            await _taskRepository.Insert(task);
        }

        public System.Threading.Tasks.Task AddTask()
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<IEnumerable<Domain.Task.Task>> GetTasks()
        {
            return await _taskRepository.GetAll();
        }

    }
}
