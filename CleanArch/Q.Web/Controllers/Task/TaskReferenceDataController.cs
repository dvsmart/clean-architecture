using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Task;
using Q.Web.Models.Task;

namespace Q.Web.Controllers.Task
{
    [Authorize]
    [Route("api/task")]
    [ApiController]
    public class TaskReferenceDataController : ControllerBase
    {
        private readonly ITaskStatusService _taskStatusService;
        private readonly ITaskPriorityService _taskPriorityService;
        private readonly IOutputConverter _outputConverter;

        public TaskReferenceDataController(IOutputConverter outputConverter, ITaskStatusService taskStatusService, ITaskPriorityService taskPriorityService)
        {
            _outputConverter = outputConverter;
            _taskPriorityService = taskPriorityService;
            _taskStatusService = taskStatusService;
        }

        [HttpGet]
        [Route("Status")]
        public async Task<IActionResult> GetTaskStatus()
        {
            var taskStatus = await _taskStatusService.List();
            return new OkObjectResult(_outputConverter.Map<List<TaskStatusModel>>(taskStatus));
        }

        [HttpGet]
        [Route("Priorities")]
        public async Task<IActionResult> GetTaskPriorities()
        {
            var taskPriorities = await _taskPriorityService.List();
            return new OkObjectResult(_outputConverter.Map<List<TaskPriorityModel>>(taskPriorities));
        }
    }
}
