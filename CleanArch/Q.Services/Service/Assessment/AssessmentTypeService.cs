using Q.Domain;
using Q.Domain.Assessment;
using Q.Infrastructure;
using Q.Services.Interfaces.Assessment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Q.Services.Service.Assessment
{
    public class AssessmentTypeService : IAssessmentTypeService
    {
        private readonly IGenericRepository<AssessmentType> _assessmentTypeRepository;

        public AssessmentTypeService(IGenericRepository<AssessmentType> assessmentTypeRepository)
        {
            _assessmentTypeRepository = assessmentTypeRepository;
        }
        public async Task<IEnumerable<AssessmentType>> GetAssessmentTypes()
        {
            return await _assessmentTypeRepository.GetAllAsync();
        }
    }
}
