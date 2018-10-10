using Q.Domain;
using Q.Domain.Assessment;
using Q.Services.Interfaces.Assessment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Assessment
{
    public class AssessmentStatusService : IAssessmentStatusService
    {
        private readonly IGenericRepository<AssessmentStatus> _assessmentStatusRepository;

        public AssessmentStatusService(IGenericRepository<AssessmentStatus> assessmentStatusRepository)
        {
            _assessmentStatusRepository = assessmentStatusRepository;
        }

        public async Task<IEnumerable<AssessmentStatus>> GetAssessmentStatuses()
        {
            return await _assessmentStatusRepository.GetAllAsync();
        }
      
    }
}
