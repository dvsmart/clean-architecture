using Q.Domain;
using Q.Domain.Assessment;
using Q.Infrastructure;
using Q.Services.Interfaces.Assessment;
using Q.Services.Interfaces.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Assessment
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IRepository<Domain.Assessment.Assessment> _assessmentRepository;

        public AssessmentService(IRepository<Domain.Assessment.Assessment> assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
        }

        public async Task<PagedResult<Domain.Assessment.Assessment>> GetAll(int page, int? pageSize)
        {
            return await _assessmentRepository.GetAll(page, pageSize);
        }
    }
}
