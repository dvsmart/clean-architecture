using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Service.Interfaces;
using Q.Web.Presenters.Task;

namespace Q.Web.Controllers.Task
{
    [Produces("application/json")]
    [Route("api/Task")]
    public class TaskController : Controller
    {
        private readonly IInputExecuteBoundary _taskInteractor;
        private readonly TaskPresenter _taskPresenter;

        public TaskController(IInputExecuteBoundary taskInteractor, TaskPresenter taskPresenter)
        {
            _taskInteractor = taskInteractor;
            _taskPresenter = taskPresenter;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<IActionResult> List()
        {
            await _taskInteractor.Execute();
            return Ok(_taskPresenter.ViewModel);
        }
    }
}