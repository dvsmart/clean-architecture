using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Assessment;
using Q.Web.Helpers;
using Q.Web.Models;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _assessmentService.GetById(id);
            var model = _outputConverter.Map<CreateAssessmentRequest>(res);
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


        [HttpDelete("{recordId}")]
        public async Task<IActionResult> Delete(int recordId)
        {
            await _assessmentService.Delete(recordId);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateAssessmentRequest createAssessmentRequest)
        {
            if (createAssessmentRequest == null)
                return new BadRequestResult();
            // var assessmentDto = _outputConverter.Map<Domain.Assessment.Assessment>(createAssessmentRequest);
            var assessmentDto = new Domain.Assessment.Assessment
            {
                ScopeId = createAssessmentRequest.ScopeId.Value,
                Title = createAssessmentRequest.Title,
                Reference = createAssessmentRequest.Reference,
                TypeId = createAssessmentRequest.AssessmentTypeId,
                AddedDate = DateTime.Now,
                AddedBy = 1,
                PublishedBy = createAssessmentRequest.Published.Value ? 1 : (int?)null,
                PublishedDate = createAssessmentRequest.Published.Value ? DateTime.Now : (DateTime?)null
            };
            var response = await _assessmentService.Insert(assessmentDto);
            return Ok(response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(int id, [FromBody]CreateAssessmentRequest createAssessmentRequest)
        {
            if (createAssessmentRequest == null)
                return new BadRequestResult();
            var assessmentDto = _outputConverter.Map<Domain.Assessment.Assessment>(createAssessmentRequest);
            var response = await _assessmentService.Update(assessmentDto);
            return Ok(response);
        }
    }
}
