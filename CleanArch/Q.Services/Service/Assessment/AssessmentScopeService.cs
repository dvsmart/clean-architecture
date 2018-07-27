﻿using Q.Domain.Assessment;
using Q.Infrastructure;
using Q.Services.Interfaces.Assessment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Assessment
{
    public class AssessmentScopeService : IAssessmentScopeService
    {
        private readonly IRepository<AssessmentScope> _assessmentScopeRepository;

        public AssessmentScopeService(IRepository<AssessmentScope> assessmentScopeRepository)
        {
            _assessmentScopeRepository = assessmentScopeRepository;
        }

        public async Task<IEnumerable<AssessmentScope>> GetAssessmentScopes()
        {
            return await _assessmentScopeRepository.GetAll();
        }
    }
}
