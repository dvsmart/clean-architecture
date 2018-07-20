using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Assessment;
using Q.Web.Helpers;
using Q.Web.Models.Assessment;

namespace Q.Web.Controllers.Assessment
{
    [Produces("application/json")]
    [Route("api/Assessment")]
    public class AssessmentController : Controller
    {
        private readonly IAssessmentService _assessmentService;
        private readonly IOutputConverter _outputConverter;

        public AssessmentController(IAssessmentService assessmentService, IOutputConverter outputConverter)
        {
            _assessmentService = assessmentService;
            _outputConverter = outputConverter;
        }

        // GET: api/Assessment
        [HttpGet]
        public IActionResult Get(int page, int pageSize)
        {
            var data = _assessmentService.GetAll(page, pageSize);
            if (data != null && data.Result != null)
            {
                var assessments = data.Result.Results != null ? _outputConverter.Map<List<AssessmentListModel>>(data.Result.Results) : null;
                var result = assessments.GetPagedResult(data.Result.PageSize, data.Result.CurrentPage, data.Result.RowCount);
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        // GET: api/Assessment/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Assessment
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Assessment/5
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
