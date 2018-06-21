using Q.Infrastructure;
using Q.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            var task = await _taskRepository.Get(id);
            await _taskRepository.Delete(task);
        }

        public async Task<IEnumerable<Domain.Task.Task>> GetTasks()
        {
            return await _taskRepository.GetAll();
        }

        public  async System.Threading.Tasks.Task UpdateTask(int id, Domain.Task.Task task)
        {
            var taskDto = await _taskRepository.Get(id);
            if(taskDto != null)
            {
                taskDto.Description = task.Description;
                taskDto.TaskStatusId = task.TaskStatusId;
                taskDto.TaskPriorityId = task.TaskPriorityId;
                taskDto.Name = task.Name;
                taskDto.ModifiedDate = DateTime.Now;
                taskDto.StartDate = task.StartDate;
                taskDto.DueDate = task.DueDate;
            }
            await _taskRepository.Update(taskDto);
        }
    }
}
