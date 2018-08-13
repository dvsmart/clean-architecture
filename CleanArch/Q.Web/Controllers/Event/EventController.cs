using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Event;
using Q.Web.Filters;
using Q.Web.Helpers;
using Q.Web.Models.Event;

namespace Q.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    [ValidateModel]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IOutputConverter _outputConverter;

        public EventController(IEventService eventService, IOutputConverter outputConverter)
        {
            _eventService = eventService;
            _outputConverter = outputConverter;
        }


        [HttpGet]
        public IActionResult Get(int page,int pageSize)
        {
            var data = _eventService.GetAll(page,pageSize);
            if (data != null && data.Result != null)
            {
                var tasks = data.Result.Results != null ? _outputConverter.Map<List<EventModel>>(data.Result.Results) : null;
                var result = tasks.GetPagedResult(data.Result.PageSize, data.Result.CurrentPage, data.Result.RowCount);
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }
       
    }
}
