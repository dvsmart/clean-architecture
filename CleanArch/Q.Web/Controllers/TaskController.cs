﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces;
using Q.Web.Filters;
using Q.Web.Models;

namespace Q.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Task")]
    [ValidateModel]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IOutputConverter _outputConverter;
        private readonly ITaskStatusService _taskStatusService;
        private readonly ITaskPriorityService _taskPriorityService;

        public TaskController(ITaskService taskService, IOutputConverter outputConverter, ITaskStatusService taskStatusService,ITaskPriorityService taskPriorityService)
        {
            _taskService = taskService;
            _outputConverter = outputConverter;
            _taskPriorityService = taskPriorityService;
            _taskStatusService = taskStatusService;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _taskService.GetTasks();
            return new OkObjectResult(_outputConverter.Map<List<TaskModel>>(tasks));
        }

        // GET: api/Task/5
        [HttpGet("{id}", Name = "GetTask")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Task
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TaskModel taskModel)
        {
            var task = _outputConverter.Map<Domain.Task.Task>(taskModel);
            await _taskService.AddTask(task);
            return Ok();
        }
        
        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TaskModel taskModel)
        {
            var task = _outputConverter.Map<Domain.Task.Task>(taskModel);
            await _taskService.UpdateTask(id, task);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteTask(id);
            return Ok();
        }

        [HttpGet]
        [Route("Taskstatus")]
        public async Task<IActionResult> GetTaskStatus()
        {
            var taskStatus =  await _taskStatusService.List();
            return new OkObjectResult(_outputConverter.Map<List<TaskStatusModel>>(taskStatus));
        }

        [HttpGet]
        [Route("Taskpriorities")]
        public async Task<IActionResult> GetTaskPriorities()
        {
            var taskPriorities = await _taskPriorityService.List();
            return new OkObjectResult(_outputConverter.Map<List<TaskPriorityModel>>(taskPriorities));
        }
    }
}
