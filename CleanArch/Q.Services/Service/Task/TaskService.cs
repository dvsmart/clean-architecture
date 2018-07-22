using Q.Domain;
using Q.Domain.Task;
using Q.Infrastructure;
using Q.Services.Interfaces.Generic;
using Q.Services.Interfaces.Task;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Domain.Task.Task> GetTaskById(int id)
        {
            return await _taskRepository.Get(id);
        }

        public async Task<IEnumerable<Domain.Task.Task>> GetTasks()
        {
            var tasks =  await _taskRepository.List(true);
            return tasks;
        }

        public IEnumerable<Domain.Task.Task> GetTasksByStatus(string status)
        {
            return _taskRepository.GetFilteredData().Where(x => x.TaskStatus.Name.Equals(status)).ToList();
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

        public async Task<PagedResult<Domain.Task.Task>> GetAll(int page, int? pageSize)
        {
            return await _taskRepository.GetAll(page, pageSize);
        }

        public System.Threading.Tasks.Task DeleteAll(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
