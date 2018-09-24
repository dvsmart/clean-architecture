using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Assessment;
using Q.Services.Interfaces.Reference;
using Q.Web.Models.Assessment;

namespace Q.Web.Controllers.Assessment
{

    [Authorize]
    [Produces("application/json")]
    [Route("api/AssessmentReference")]
    public class ReferenceDataController : Controller
    {
        private readonly IAssessmentScopeService _scopeService;
        private readonly IAssessmentStatusService _statusService;
        private readonly IAssessmentTypeService _typeService;
        private readonly IReferenceService _referenceService;

        public ReferenceDataController(IOutputConverter outputConverter, IAssessmentScopeService scopeService, IAssessmentStatusService statusService, IAssessmentTypeService typeService, IReferenceService referenceService)
        {
            _scopeService = scopeService;
            _statusService = statusService;
            _typeService = typeService;
            _referenceService = referenceService;
        }

        [HttpGet("Scopes")]
        public async Task<IActionResult> GetAssessmentScopes()
        {
            var res = await _scopeService.GetAssessmentScopes();
            var scopes = res.Select(x => new ScopeModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(scopes);
        }


        [HttpGet("Statuses")]
        public async Task<IActionResult> GetAssessmentStatuses()
        {
            var res = await _statusService.GetAssessmentStatuses();
            var statuses = res.Select(x => new StatusModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(statuses);
        }

        [HttpGet("Types")]
        public async Task<IActionResult> GetAssessmentTypes()
        {
            var res = await _typeService.GetAssessmentTypes();
            var types = res.Select(x => new TypeModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(types);
        }

        [HttpGet("Frequencies")]
        public async Task<IActionResult> GetAssessmentFrequencies()
        {
            var res = await _referenceService.GetFrequencies();
            var types = res.Select(x => new TypeModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(types);
        }


    }
}
