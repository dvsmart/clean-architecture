using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Assessment;
using Q.Web.Helpers;
using Q.Web.Mappings;
using Q.Web.Models;
using Q.Web.Models.Assessment;

namespace Q.Web.Controllers.Assessment
{
    [Authorize]
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
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            var data = await _assessmentService.GetAll(page, pageSize);
            if (data != null)
            {
                var assessments = data.Results != null ? _outputConverter.Map<List<AssessmentListModel>>(data.Results) : null;
                var result = assessments.GetPagedResult(data.PageSize, data.CurrentPage,data.RowCount);
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _assessmentService.GetById(id);
            var model = Mapper.MapToAssessmentModel(res);
            return Ok(model);
        }

        [HttpPost]
        [Route("deleteAll")]
        public async Task<HttpResponseMessage> DeleteAll([FromBody]DeleteModel deleteModel)
        {
            if (deleteModel == null && !deleteModel.Ids.Any())
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            await _assessmentService.DeleteAll(deleteModel.Ids);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int recordId)
        {
            await _assessmentService.Delete(recordId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateAssessmentRequest createAssessmentRequest)
        {
            if (createAssessmentRequest == null)
                return new BadRequestResult();
            var assessmentDto = Mapper.MapToAssessmentDto(createAssessmentRequest);
            var response = await _assessmentService.Insert(assessmentDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody]CreateAssessmentRequest editAssessmentRequest)
        {
            if (editAssessmentRequest == null)
                return new BadRequestResult();
            var assessmentDto = Mapper.MapToAssessmentDto(editAssessmentRequest);
            var response = await _assessmentService.Update(assessmentDto);
            return Ok(response);
        }
    }
}
