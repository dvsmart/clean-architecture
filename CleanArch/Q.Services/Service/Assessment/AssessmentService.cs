using Q.Domain;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Helper;
using Q.Services.Interfaces.Assessment;
using System.Collections.Generic;
using System.Linq;
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

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var assessment = await _assessmentRepository.Get(id);
            await _assessmentRepository.Remove(assessment);
        }

        public async System.Threading.Tasks.Task DeleteAll(List<int> ids)
        {
            var assessments = _assessmentRepository.FindBy(x => ids.Contains(x.Id)).ToList();
            await _assessmentRepository.DeleteAll(assessments);
        }

        public async Task<PagedResult<Domain.Assessment.Assessment>> GetAll(int page, int? pageSize)
        {
            return await _assessmentRepository.GetAll(page, pageSize);
        }

        public async Task<Domain.Assessment.Assessment> GetById(int id)
        {
            return await _assessmentRepository.Get(id);
        }

        public async Task<SaveResponseDto> Insert(Domain.Assessment.Assessment entity)
        {
            var id = _assessmentRepository.LatestRecordId().Value;
            entity.DataId = DataIdGenerationService.GenerateDataId(id, "AM");
            var response = await _assessmentRepository.Insert(entity);
            return new SaveResponseDto
            {
                SavedDataId = entity.DataId,
                SavedEntityId = entity.Id,
                SaveSuccessful = response
            };
        }

        public async Task<SaveResponseDto> Update(Domain.Assessment.Assessment entity)
        {
            if(entity.DataId == null)
            {
                var id = _assessmentRepository.LatestRecordId().Value;
                entity.DataId = DataIdGenerationService.GenerateDataId(id, "AM");
            }
            var response = await _assessmentRepository.Update(entity);
            return new SaveResponseDto
            {
                SavedDataId = entity.DataId,
                SavedEntityId = entity.Id,
                SaveSuccessful = response ? response : false,
                ErrorMessage = response == true ? string.Empty : "update failed"
            };
        }
    }
}
