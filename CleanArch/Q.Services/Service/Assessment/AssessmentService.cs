using Q.Domain;
using Q.Domain.Assessment;
using Q.Infrastructure;
using Q.Services.Interfaces.Assessment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Services.Service.Assessment
{
    public class AssessmentService : IAssessmentService
    {

        private readonly IRepository<Domain.Assessment.Assessment> _assessmentRepository;

        public AssessmentService(IRepository<Domain.Assessment.Assessment> assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
        }
        public PagedResult<Domain.Assessment.Assessment> GetAll(int page, int? pageSize)
        {
            return _assessmentRepository.GetAll(page, pageSize);
        }
    }
}
