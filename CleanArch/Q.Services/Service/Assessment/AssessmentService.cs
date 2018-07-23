using Q.Domain;
using Q.Domain.Assessment;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.Assessment;
using Q.Services.Interfaces.Generic;
using System.Collections.Generic;
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

        public System.Threading.Tasks.Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAll(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedResult<Domain.Assessment.Assessment>> GetAll(int page, int? pageSize)
        {
            return await _assessmentRepository.GetAll(page, pageSize);
        }

        public Task<SaveResponseDto> Insert(Domain.Assessment.Assessment entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
