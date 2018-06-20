using Microsoft.AspNetCore.Mvc;
using Q.Service.Interfaces;
using Q.Service.UseCases.Task;
using System.Collections.Generic;

namespace Q.Web.Presenters.Task
{
    public class TaskPresenter : IOutputBoundary<List<TaskDto>>
    {
        public IActionResult ViewModel { get; private set; }
        public List<TaskDto> Output { get; private set; }

        private readonly IOutputConverter _outputConverter;

        public TaskPresenter(IOutputConverter outputConverter)
        {
            _outputConverter = outputConverter;
        }

        public void Populate(List<TaskDto> response)
        {
            Output = response;
            if(Output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            var taskListModel = _outputConverter.Map<List<TaskDto>>(Output);
            ViewModel = new OkObjectResult(taskListModel);
        }
    }
}
