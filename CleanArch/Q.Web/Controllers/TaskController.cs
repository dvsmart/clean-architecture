using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces;
using Q.Web.Models;

namespace Q.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Task")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IOutputConverter _outputConverter;

        public TaskController(ITaskService taskService, IOutputConverter outputConverter)
        {
            _taskService = taskService;
            _outputConverter = outputConverter;
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
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Task/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
