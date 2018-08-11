﻿using Q.Domain.Common;
using Q.Infrastructure;
using Q.Services.Interfaces.Reference;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Reference
{
    public class ReferenceService : IReferenceService
    {
        private readonly IRepository<RecurrenceType> _referenceRepository;

        public ReferenceService(IRepository<RecurrenceType> referenceRepository)
        {
            _referenceRepository = referenceRepository;
        }
        public async Task<IEnumerable<RecurrenceType>> GetFrequencies()
        {
            return await _referenceRepository.GetAll();
        }
    }
}