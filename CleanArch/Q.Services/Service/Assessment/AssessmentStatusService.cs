using Q.Domain.Assessment;
using Q.Infrastructure;
using Q.Services.Interfaces.Assessment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Assessment
{
    public class AssessmentStatusService : IAssessmentStatusService
    {
        private readonly IRepository<AssessmentStatus> _assessmentStatusRepository;

        public AssessmentStatusService(IRepository<AssessmentStatus> assessmentStatusRepository)
        {
            _assessmentStatusRepository = assessmentStatusRepository;
        }

        public async Task<IEnumerable<AssessmentStatus>> GetAssessmentStatuses()
        {
            return await _assessmentStatusRepository.GetAll();
        }
      
    }
}
