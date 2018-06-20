using Q.Service.Interfaces;
using System;

namespace Q.Service.UseCases.Task
{
    using Q.Domain.Task;
    using System.Collections.Generic;

    public class GetTasksInteractor : IInputExecuteBoundary
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IOutputConverter _outputConverter;
        private readonly IOutputBoundary<List<TaskDto>> _outputBoundary;

        public GetTasksInteractor(IRepository<Task> taskRepository, IOutputConverter outputConverter, IOutputBoundary<List<TaskDto>> outputBoundary)
        {
            _taskRepository = taskRepository;
            _outputConverter = outputConverter;
            _outputBoundary = outputBoundary;

        }

        public async System.Threading.Tasks.Task Execute()
        {
            var allTasks = await _taskRepository.GetAll();
            var tasksDto = _outputConverter.Map<List<TaskDto>>(allTasks);
            _outputBoundary.Populate(tasksDto);
        }
    }
}
